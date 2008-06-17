using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Duplicati.Datamodel;

namespace Duplicati
{
    public partial class RestoreBackup : Form
    {
        private Schedule m_schedule;

        public RestoreBackup()
        {
            InitializeComponent();
            backupItems.listView.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(listView_ItemSelectionChanged);
        }

        void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            TargetFolder_TextChanged(null, null);
        }

        public void Setup(Schedule schedule)
        {
            m_schedule = schedule;
            backupItems.Setup(schedule);
        }

        private void TargetFolder_TextChanged(object sender, EventArgs e)
        {
            OKBtn.Enabled = backupItems.listView.SelectedItems.Count == 1 && TargetFolder.Text.Trim().Length > 0;
        }

        private void SelectTargetFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
                TargetFolder.Text = folderBrowserDialog.SelectedPath;
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            DateTime dt = new DateTime();
            try
            {
                dt = Timeparser.ParseDuplicityFileTime(backupItems.listView.SelectedItems[0].Text);
            }
            catch(Exception ex)
            {
                if (MessageBox.Show(this, "An error occured while parsing the time: " + ex.Message + "\r\nDo you want to try to restore the most current backup instead?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3) != DialogResult.Yes)
                    return;

                dt = new DateTime();
            }

            if (System.IO.Directory.GetFileSystemEntries(TargetFolder.Text).Length > 0)
                if (MessageBox.Show(this, "The selected folder is not empty.\r\nDo you want to restore there anyway?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3) != DialogResult.Yes)
                    return;

            Program.WorkThread.AddTask(new RestoreTask(m_schedule, TargetFolder.Text, dt));
            Program.ShowStatus();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}