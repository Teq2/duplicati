#region Disclaimer / License
// Copyright (C) 2008, Kenneth Skovhede
// http://www.hexad.dk, opensource@hexad.dk
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
// 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Wizard;
using Duplicati.Datamodel;

namespace Duplicati.GUI.Wizard_pages.Backends.FTP
{
    public partial class FTPOptions : WizardControl
    {
        private bool m_warnedPassword = false; 
        private bool m_warnedUsername = false;
        private bool m_hasTested;
        private bool m_warnedPath;
        
        private Duplicati.Datamodel.Backends.FTP m_ftp;

        public FTPOptions()
            : base("Backup storage options", "On this page you can select where to store the backup data.")
        {
            InitializeComponent();

            base.PageEnter += new PageChangeHandler(FTPOptions_PageEnter);
            base.PageLeave += new PageChangeHandler(FTPOptions_PageLeave);
        }

        void FTPOptions_PageLeave(object sender, PageChangedArgs args)
        {
            SaveSettings();

            if (args.Direction == PageChangedDirection.Back)
                return;

            if (!ValidateForm())
            {
                args.Cancel = true;
                return;
            }

            if (!m_hasTested)
                switch (MessageBox.Show(this, "Do you want to test the connection?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                { 
                    case DialogResult.Yes:
                        TestConnection_Click(null, null);
                        if (!m_hasTested)
                        {
                            args.Cancel = true;
                            return;
                        }
                        break;
                    case DialogResult.No:
                        break;
                    default: //Cancel
                        args.Cancel = true;
                        return;
                }

            SaveSettings();
            args.NextPage = new Add_backup.AdvancedOptions();
        }

        void FTPOptions_PageEnter(object sender, PageChangedArgs args)
        {
            m_ftp = new Duplicati.Datamodel.Backends.FTP(((Schedule)m_settings["Schedule"]).Tasks[0]);

            if (m_settings.ContainsKey("FTP:HasTested"))
                m_hasTested = (bool)m_settings["FTP:HasTested"];

            if (m_settings.ContainsKey("FTP:WarnedPath"))
                m_warnedPath = (bool)m_settings["FTP:WarnedPath"];

            if (m_settings.ContainsKey("FTP:WarnedUsername"))
                m_warnedUsername = (bool)m_settings["FTP:WarnedUsername"];

            if (m_settings.ContainsKey("FTP:WarnedPassword"))
                m_warnedPassword = (bool)m_settings["FTP:WarnedPassword"];

            if (!m_valuesAutoLoaded)
            {
                Servername.Text = m_ftp.Host;
                Path.Text = m_ftp.Folder;
                Username.Text = m_ftp.Username;
                Password.Text = m_ftp.Password;
                Port.Value = m_ftp.Port;
            }
        }

        private bool ValidateForm()
        {
            if (Servername.Text.Trim().Length <= 0)
            {
                MessageBox.Show(this, "You must enter the name of the server", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                try { Servername.Focus(); }
                catch { }

                return false;
            }

            if (Username.Text.Trim().Length <= 0 && !m_warnedUsername)
            {
                if (MessageBox.Show(this, "You have not entered a username.\nThis is fine if the server allows anonymous uploads, but likely a username is required\nProceed without a password?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) != DialogResult.Yes)
                {
                    try { Username.Focus(); }
                    catch { }

                    return false;
                }
            }

            if (Password.Text.Trim().Length <= 0 && !m_warnedPassword)
            {
                if (MessageBox.Show(this, "You have not entered a password.\nProceed without a password?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) != DialogResult.Yes)
                {
                    try { Password.Focus(); }
                    catch { }

                    return false;
                }
                m_warnedPassword = true;
            }

            return true;
        }

        private void SaveSettings()
        {
            m_ftp.Host = Servername.Text;
            m_ftp.Folder = Path.Text;
            m_ftp.Username = Username.Text;
            m_ftp.Password = Password.Text;
            m_ftp.Port = (int)Port.Value;

            m_ftp.SetService();

            m_settings["FTP:HasWarned"] = m_hasTested;
            m_settings["FTP:WarnedPath"] = m_warnedPath;
            m_settings["FTP:WarnedUsername"] = m_warnedUsername;
            m_settings["FTP:WarnedPassword"] = m_warnedPassword;
        }

        private void TestConnection_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                SaveSettings();

                try
                {
                    string hostname = m_ftp.GetDestinationPath();
                    Dictionary<string, string> options = new Dictionary<string, string>();
                    m_ftp.GetOptions(options);
                    string[] files = Duplicati.Library.Main.Interface.List(hostname, options);

                    MessageBox.Show(this, "Connection succeeded!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_hasTested = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Connection Failed: " + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void Port_ValueChanged(object sender, EventArgs e)
        {
            m_hasTested = false;
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            m_hasTested = false;
            m_warnedPassword = false;
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {
            m_hasTested = false;
            m_warnedUsername = false;
        }

        private void Path_TextChanged(object sender, EventArgs e)
        {
            m_hasTested = false;
            m_warnedPath = false;
        }

        private void Servername_TextChanged(object sender, EventArgs e)
        {
            m_hasTested = false;
        }
    }
}