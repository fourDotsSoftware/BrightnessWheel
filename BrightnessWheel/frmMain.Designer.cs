namespace BrightnessWheel
{
    partial class frmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.notMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblOption = new System.Windows.Forms.Label();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToWindowsSystemTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runAtWindowsStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadSoftwareToolStripMenuItem = new com.softpcapps.download_software.DownloadSoftwareToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languages1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languages2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pleaseDonateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForNewVersionEachWeekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiHelpFeedback = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForNewVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.followUsOnTwitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visit4dotsSoftwareWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.youtubeChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.fplWheelOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblStep = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslProject = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.proxySettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMain.SuspendLayout();
            this.msMain.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notMain
            // 
            this.notMain.ContextMenuStrip = this.cmsMain;
            resources.ApplyResources(this.notMain, "notMain");
            this.notMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notMain_MouseDoubleClick);
            // 
            // cmsMain
            // 
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.cmsMain.Name = "cmsMain";
            resources.ApplyResources(this.cmsMain, "cmsMain");
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Image = global::BrightnessWheel.Properties.Resources.exit;
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            resources.ApplyResources(this.exitToolStripMenuItem1, "exitToolStripMenuItem1");
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // lblOption
            // 
            resources.ApplyResources(this.lblOption, "lblOption");
            this.lblOption.BackColor = System.Drawing.Color.Transparent;
            this.lblOption.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblOption.Name = "lblOption";
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.downloadSoftwareToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.msMain, "msMain");
            this.msMain.Name = "msMain";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openProjectToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.saveProjectAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Image = global::BrightnessWheel.Properties.Resources.folder;
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            resources.ApplyResources(this.openProjectToolStripMenuItem, "openProjectToolStripMenuItem");
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Image = global::BrightnessWheel.Properties.Resources.disk_blue;
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            resources.ApplyResources(this.saveProjectToolStripMenuItem, "saveProjectToolStripMenuItem");
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
            // 
            // saveProjectAsToolStripMenuItem
            // 
            this.saveProjectAsToolStripMenuItem.Name = "saveProjectAsToolStripMenuItem";
            resources.ApplyResources(this.saveProjectAsToolStripMenuItem, "saveProjectAsToolStripMenuItem");
            this.saveProjectAsToolStripMenuItem.Click += new System.EventHandler(this.saveProjectAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::BrightnessWheel.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimizeToWindowsSystemTrayToolStripMenuItem,
            this.runAtWindowsStartupToolStripMenuItem,
            this.optionsToolStripMenuItem1});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            // 
            // minimizeToWindowsSystemTrayToolStripMenuItem
            // 
            this.minimizeToWindowsSystemTrayToolStripMenuItem.CheckOnClick = true;
            this.minimizeToWindowsSystemTrayToolStripMenuItem.Name = "minimizeToWindowsSystemTrayToolStripMenuItem";
            resources.ApplyResources(this.minimizeToWindowsSystemTrayToolStripMenuItem, "minimizeToWindowsSystemTrayToolStripMenuItem");
            this.minimizeToWindowsSystemTrayToolStripMenuItem.Click += new System.EventHandler(this.minimizeToWindowsSystemTrayToolStripMenuItem_Click);
            // 
            // runAtWindowsStartupToolStripMenuItem
            // 
            this.runAtWindowsStartupToolStripMenuItem.Name = "runAtWindowsStartupToolStripMenuItem";
            resources.ApplyResources(this.runAtWindowsStartupToolStripMenuItem, "runAtWindowsStartupToolStripMenuItem");
            this.runAtWindowsStartupToolStripMenuItem.Click += new System.EventHandler(this.runAtWindowsStartupToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem1
            // 
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            resources.ApplyResources(this.optionsToolStripMenuItem1, "optionsToolStripMenuItem1");
            this.optionsToolStripMenuItem1.Click += new System.EventHandler(this.optionsToolStripMenuItem1_Click);
            // 
            // downloadSoftwareToolStripMenuItem
            // 
            this.downloadSoftwareToolStripMenuItem.Name = "downloadSoftwareToolStripMenuItem";
            resources.ApplyResources(this.downloadSoftwareToolStripMenuItem, "downloadSoftwareToolStripMenuItem");
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languages1ToolStripMenuItem,
            this.languages2ToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // languages1ToolStripMenuItem
            // 
            this.languages1ToolStripMenuItem.Name = "languages1ToolStripMenuItem";
            resources.ApplyResources(this.languages1ToolStripMenuItem, "languages1ToolStripMenuItem");
            // 
            // languages2ToolStripMenuItem
            // 
            this.languages2ToolStripMenuItem.Name = "languages2ToolStripMenuItem";
            resources.ApplyResources(this.languages2ToolStripMenuItem, "languages2ToolStripMenuItem");
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpGuideToolStripMenuItem,
            this.pleaseDonateToolStripMenuItem1,
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem,
            this.checkForNewVersionEachWeekToolStripMenuItem,
            this.tiHelpFeedback,
            this.checkForNewVersionToolStripMenuItem,
            this.proxySettingsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.followUsOnTwitterToolStripMenuItem,
            this.visit4dotsSoftwareWebsiteToolStripMenuItem,
            this.youtubeChannelToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // helpGuideToolStripMenuItem
            // 
            this.helpGuideToolStripMenuItem.Image = global::BrightnessWheel.Properties.Resources.help2;
            this.helpGuideToolStripMenuItem.Name = "helpGuideToolStripMenuItem";
            resources.ApplyResources(this.helpGuideToolStripMenuItem, "helpGuideToolStripMenuItem");
            this.helpGuideToolStripMenuItem.Click += new System.EventHandler(this.helpGuideToolStripMenuItem_Click);
            // 
            // pleaseDonateToolStripMenuItem1
            // 
            this.pleaseDonateToolStripMenuItem1.BackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.pleaseDonateToolStripMenuItem1, "pleaseDonateToolStripMenuItem1");
            this.pleaseDonateToolStripMenuItem1.Name = "pleaseDonateToolStripMenuItem1";
            this.pleaseDonateToolStripMenuItem1.Click += new System.EventHandler(this.pleaseDonateToolStripMenuItem1_Click);
            // 
            // dotsSoftwarePRODUCTCATALOGToolStripMenuItem
            // 
            resources.ApplyResources(this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem, "dotsSoftwarePRODUCTCATALOGToolStripMenuItem");
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.ForeColor = System.Drawing.Color.DarkBlue;
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.Name = "dotsSoftwarePRODUCTCATALOGToolStripMenuItem";
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.Click += new System.EventHandler(this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem_Click);
            // 
            // checkForNewVersionEachWeekToolStripMenuItem
            // 
            this.checkForNewVersionEachWeekToolStripMenuItem.CheckOnClick = true;
            this.checkForNewVersionEachWeekToolStripMenuItem.Name = "checkForNewVersionEachWeekToolStripMenuItem";
            resources.ApplyResources(this.checkForNewVersionEachWeekToolStripMenuItem, "checkForNewVersionEachWeekToolStripMenuItem");
            this.checkForNewVersionEachWeekToolStripMenuItem.Click += new System.EventHandler(this.checkForNewVersionEachWeekToolStripMenuItem_Click);
            // 
            // tiHelpFeedback
            // 
            this.tiHelpFeedback.Name = "tiHelpFeedback";
            resources.ApplyResources(this.tiHelpFeedback, "tiHelpFeedback");
            this.tiHelpFeedback.Click += new System.EventHandler(this.tiHelpFeedback_Click);
            // 
            // checkForNewVersionToolStripMenuItem
            // 
            this.checkForNewVersionToolStripMenuItem.Name = "checkForNewVersionToolStripMenuItem";
            resources.ApplyResources(this.checkForNewVersionToolStripMenuItem, "checkForNewVersionToolStripMenuItem");
            this.checkForNewVersionToolStripMenuItem.Click += new System.EventHandler(this.checkForNewVersionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // followUsOnTwitterToolStripMenuItem
            // 
            this.followUsOnTwitterToolStripMenuItem.Image = global::BrightnessWheel.Properties.Resources.twitter_24;
            this.followUsOnTwitterToolStripMenuItem.Name = "followUsOnTwitterToolStripMenuItem";
            resources.ApplyResources(this.followUsOnTwitterToolStripMenuItem, "followUsOnTwitterToolStripMenuItem");
            this.followUsOnTwitterToolStripMenuItem.Click += new System.EventHandler(this.followUsOnTwitterToolStripMenuItem_Click);
            // 
            // visit4dotsSoftwareWebsiteToolStripMenuItem
            // 
            this.visit4dotsSoftwareWebsiteToolStripMenuItem.Image = global::BrightnessWheel.Properties.Resources.earth;
            this.visit4dotsSoftwareWebsiteToolStripMenuItem.Name = "visit4dotsSoftwareWebsiteToolStripMenuItem";
            resources.ApplyResources(this.visit4dotsSoftwareWebsiteToolStripMenuItem, "visit4dotsSoftwareWebsiteToolStripMenuItem");
            this.visit4dotsSoftwareWebsiteToolStripMenuItem.Click += new System.EventHandler(this.visit4dotsSoftwareWebsiteToolStripMenuItem_Click);
            // 
            // youtubeChannelToolStripMenuItem
            // 
            this.youtubeChannelToolStripMenuItem.Image = global::BrightnessWheel.Properties.Resources.youtube_32;
            this.youtubeChannelToolStripMenuItem.Name = "youtubeChannelToolStripMenuItem";
            resources.ApplyResources(this.youtubeChannelToolStripMenuItem, "youtubeChannelToolStripMenuItem");
            this.youtubeChannelToolStripMenuItem.Click += new System.EventHandler(this.youtubeChannelToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::BrightnessWheel.Properties.Resources.information;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Image = global::BrightnessWheel.Properties.Resources.check;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // fplWheelOptions
            // 
            resources.ApplyResources(this.fplWheelOptions, "fplWheelOptions");
            this.fplWheelOptions.Name = "fplWheelOptions";
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Image = global::BrightnessWheel.Properties.Resources.add;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            resources.ApplyResources(this.btnRemove, "btnRemove");
            this.btnRemove.Image = global::BrightnessWheel.Properties.Resources.delete;
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblStep
            // 
            resources.ApplyResources(this.lblStep, "lblStep");
            this.lblStep.BackColor = System.Drawing.Color.Transparent;
            this.lblStep.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblStep.Name = "lblStep";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslProject});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // tslProject
            // 
            this.tslProject.ForeColor = System.Drawing.Color.DimGray;
            this.tslProject.Name = "tslProject";
            resources.ApplyResources(this.tslProject, "tslProject");
            this.tslProject.Spring = true;
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Image = global::BrightnessWheel.Properties.Resources.exit;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReset
            // 
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.Image = global::BrightnessWheel.Properties.Resources.refresh;
            this.btnReset.Name = "btnReset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // proxySettingsToolStripMenuItem
            // 
            this.proxySettingsToolStripMenuItem.Name = "proxySettingsToolStripMenuItem";
            resources.ApplyResources(this.proxySettingsToolStripMenuItem, "proxySettingsToolStripMenuItem");
            this.proxySettingsToolStripMenuItem.Click += new System.EventHandler(this.proxySettingsToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblStep);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.fplWheelOptions);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblOption);
            this.Controls.Add(this.msMain);
            this.MainMenuStrip = this.msMain;
            this.Name = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.cmsMain.ResumeLayout(false);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notMain;
        private System.Windows.Forms.Label lblOption;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpGuideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pleaseDonateToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dotsSoftwarePRODUCTCATALOGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForNewVersionEachWeekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiHelpFeedback;
        private System.Windows.Forms.ToolStripMenuItem checkForNewVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem followUsOnTwitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visit4dotsSoftwareWebsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem youtubeChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button btnClose;
        private com.softpcapps.download_software.DownloadSoftwareToolStripMenuItem downloadSoftwareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runAtWindowsStartupToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem minimizeToWindowsSystemTrayToolStripMenuItem;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        private System.Windows.Forms.Label lblStep;
        public System.Windows.Forms.FlowLayoutPanel fplWheelOptions;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languages1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languages2ToolStripMenuItem;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnReset;
        public System.Windows.Forms.ToolStripStatusLabel tslProject;
        private System.Windows.Forms.ToolStripMenuItem proxySettingsToolStripMenuItem;
    }
}
