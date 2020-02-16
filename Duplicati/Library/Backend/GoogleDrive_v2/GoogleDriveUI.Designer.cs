namespace Duplicati.Library.Backend
{
    partial class GoogleDriveUI
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoogleDriveUI));
            this.TestConnection = new System.Windows.Forms.Button();
            this.SignUpLink = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Path = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.AuthID = new Duplicati.Winforms.Controls.PasswordControl();
            this.CreateFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TestConnection
            // 
            resources.ApplyResources(this.TestConnection, "TestConnection");
            this.TestConnection.Name = "TestConnection";
            this.TestConnection.UseVisualStyleBackColor = true;
            this.TestConnection.Click += new System.EventHandler(this.TestConnection_Click);
            // 
            // SignUpLink
            // 
            resources.ApplyResources(this.SignUpLink, "SignUpLink");
            this.SignUpLink.Name = "SignUpLink";
            this.SignUpLink.TabStop = true;
            this.SignUpLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GetAuth_LinkClicked);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Path
            // 
            resources.ApplyResources(this.Path, "Path");
            this.Path.Name = "Path";
            this.toolTip1.SetToolTip(this.Path, resources.GetString("Path.ToolTip"));
            this.Path.TextChanged += new System.EventHandler(this.Path_TextChanged);
            // 
            // AuthID
            // 
            this.AuthID.AskToEnterNewPassword = false;
            this.AuthID.InitialPassword = null;
            this.AuthID.IsPasswordVisible = false;
            resources.ApplyResources(this.AuthID, "AuthID");
            this.AuthID.Name = "AuthID";
            this.toolTip1.SetToolTip(this.AuthID, resources.GetString("AuthID.ToolTip"));
            this.AuthID.TextChanged += new System.EventHandler(this.AuthID_TextChanged);
            // 
            // CreateFolder
            // 
            resources.ApplyResources(this.CreateFolder, "CreateFolder");
            this.CreateFolder.Name = "CreateFolder";
            this.CreateFolder.UseVisualStyleBackColor = true;
            this.CreateFolder.Click += new System.EventHandler(this.CreateFolder_Click);
            // 
            // GoogleDriveUI
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CreateFolder);
            this.Controls.Add(this.AuthID);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.TestConnection);
            this.Controls.Add(this.SignUpLink);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GoogleDriveUI";
            this.Load += new System.EventHandler(this.GoogleDocsUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button TestConnection;
        private System.Windows.Forms.LinkLabel SignUpLink;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Path;
        private System.Windows.Forms.ToolTip toolTip1;
        private Winforms.Controls.PasswordControl AuthID;
        private System.Windows.Forms.Button CreateFolder;
    }
}
