using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Duplicati.Library.Backend
{
    public partial class GoogleDriveUI : UserControl
    {
        private const string AUTHID = "AuthID";
        private const string FOLDER = "Folder";
        private const string DEFAULTFOLDER = "Duplicati";
        private const string HAS_TESTED = "UI: Has tested";
        private const string DUPLICATI_ACTION_MARKER = "*duplicati-action*";

        private bool m_hasTested;
        private string m_uiAction = null;
        private IDictionary<string, string> m_options;

        public GoogleDriveUI(IDictionary<string, string> options)
            : this()
        {
            m_options = options;
        }

        private GoogleDriveUI()
        {
            InitializeComponent();
        }

        internal bool Save(bool validate)
        {
            Save();

            if (!validate)
                return true;

            if (!ValidateForm())
                return false;

            if (!m_hasTested)
                switch (MessageBox.Show(this, Interface.CommonStrings.ConfirmTestConnectionQuestion, Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        TestConnection_Click(null, null);
                        if (!m_hasTested)
                            return false;
                        break;
                    case DialogResult.No:
                        break;
                    default: //Cancel
                        return false;
                }

            Save();

            return true;
        }

        private void GoogleDocsUI_Load(object sender, EventArgs e)
        {
            if (m_options.ContainsKey(AUTHID))
                AuthID.Text = m_options[AUTHID];
            Path.Text = m_options.ContainsKey(FOLDER)? m_options[FOLDER]: DEFAULTFOLDER;

            if (!m_options.ContainsKey(HAS_TESTED) || !bool.TryParse(m_options[HAS_TESTED], out m_hasTested))
                m_hasTested = false;

            AuthID.AskToEnterNewPassword = m_options.ContainsKey(AUTHID);

            m_options.TryGetValue(DUPLICATI_ACTION_MARKER, out m_uiAction);
        }

        private bool ValidateForm()
        {
            if (Path.Text.Trim().Length <= 0)
            {
                MessageBox.Show(this, Strings.GoogleDriveUI.EmptyFolderPathError, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                try { Path.Focus(); }
                catch { }

                return false;
            }

            if (AuthID.Text.Trim().Length <= 0)
            {
                MessageBox.Show(this, Strings.GoogleDriveUI.EmptyAuthIDError, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                try { AuthID.Focus(); }
                catch { }

                return false;
            }

            return true;
        }

        private void Save()
        {
            m_options.Clear();
            m_options[HAS_TESTED] = m_hasTested.ToString();
            m_options[FOLDER] = Path.Text;
            m_options[AUTHID] = AuthID.Text;

            if (!string.IsNullOrEmpty(m_uiAction))
                m_options.Add(DUPLICATI_ACTION_MARKER, m_uiAction);
        }

        private void AuthID_TextChanged(object sender, EventArgs e)
        {
            m_hasTested = false;
        }

        private void Path_TextChanged(object sender, EventArgs e)
        {
            m_hasTested = false;
        }

        internal static string GetConfiguration(IDictionary<string, string> guiOptions, IDictionary<string, string> commandlineOptions)
        {
            if (guiOptions.ContainsKey(AUTHID) && !string.IsNullOrEmpty(guiOptions[AUTHID]))
                commandlineOptions["google-authid"] = guiOptions[AUTHID];

            string folder;
            guiOptions.TryGetValue(FOLDER, out folder);

            if (string.IsNullOrEmpty(folder))
                throw new Exception(string.Format(Interface.CommonStrings.ConfigurationIsMissingItemError, FOLDER));

            if (folder.StartsWith("/"))
                folder = folder.Substring(1);

            if (string.IsNullOrEmpty(folder))
                throw new Exception(string.Format(Interface.CommonStrings.ConfigurationIsMissingItemError, FOLDER));

            return "googledrive://" + guiOptions[FOLDER];
        }

        public static string PageTitle
        {
            get { return Strings.GoogleDriveUI.PageTitle; }
        }

        public static string PageDescription
        {
            get { return Strings.GoogleDriveUI.PageDescription; }
        }

        private void GetAuth_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // EditUriBuiltings.js
            // scope.oauth_create_token = Math.random().toString(36).substr(2) + Math.random().toString(36).substr(2);
            // scope.oauth_service_link = 'https://duplicati-oauth-handler.appspot.com/';
            // scope.oauth_start_link = scope.oauth_service_link + '?type=' + scope.Backend.Key + '&token=' + scope.oauth_create_token;

            byte[] buff = new byte[12];
            new System.Random().NextBytes(buff);
            string token = String.Join(String.Empty, Array.ConvertAll(buff, x => x.ToString("x2"))); 
            string url = $"https://duplicati-oauth-handler.appspot.com/?type=googledrive&token={token}";
            Duplicati.Library.Utility.UrlUtillity.OpenUrl(url);
        }

        private void TestConnection_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                bool retry = true;
                while (retry == true)
                {
                    retry = false;
                    Cursor c = this.Cursor;
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        Save();
                        Dictionary<string, string> options = new Dictionary<string, string>();
                        string destination = GetConfiguration(m_options, options);

                        bool existingBackup = false;

                        using (GoogleDrive gdrive = new GoogleDrive(destination, options))
                            foreach (Interface.IFileEntry n in gdrive.List())
                                if (n.Name.StartsWith("duplicati-"))
                                {
                                    existingBackup = true;
                                    break;
                                }

                        bool isUiAdd = string.IsNullOrEmpty(m_uiAction) || string.Equals(m_uiAction, "add", StringComparison.InvariantCultureIgnoreCase);
                        if (existingBackup && isUiAdd)
                        {
                            if (MessageBox.Show(this, string.Format(Interface.CommonStrings.ExistingBackupDetectedQuestion), Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) != DialogResult.Yes)
                                return;
                        }
                        else
                        {
                            MessageBox.Show(this, Interface.CommonStrings.ConnectionSuccess, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        m_hasTested = true;
                    }
                    catch (Interface.FolderMissingException)
                    {
                        switch (MessageBox.Show(this, Strings.GoogleDriveUI.CreateMissingFolderQuestion, Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            case DialogResult.Yes:
                                CreateFolder.PerformClick();
                                TestConnection.PerformClick();
                                return;
                            default:
                                return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, string.Format(Interface.CommonStrings.ConnectionFailure, ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        this.Cursor = c;
                    }
                }
            }
        }

        private void CreateFolder_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                bool retry = true;
                while (retry == true)
                {
                    retry = false;
                    Cursor c = this.Cursor;
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        Save();

                        Dictionary<string, string> options = new Dictionary<string, string>();
                        string destination = GetConfiguration(m_options, options);

                        using (GoogleDrive gdrive = new GoogleDrive(destination, options))
                        {
                            gdrive.CreateFolder();
                        }

                        MessageBox.Show(this, Strings.GoogleDriveUI.FolderCreated, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        m_hasTested = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, string.Format(Interface.CommonStrings.ConnectionFailure, ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        this.Cursor = c;
                    }
                }
            }
        }
    }
}
