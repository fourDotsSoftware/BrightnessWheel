namespace BrightnessWheel
{
    partial class frmProxySettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProxySettings));
            this.rdAutoDetect = new System.Windows.Forms.RadioButton();
            this.rdSet = new System.Windows.Forms.RadioButton();
            this.grpProxySettings = new System.Windows.Forms.GroupBox();
            this.chkDefaultCredentials = new System.Windows.Forms.CheckBox();
            this.txtProxyPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProxyUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProxyPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProxyHost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpProxySettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdAutoDetect
            // 
            resources.ApplyResources(this.rdAutoDetect, "rdAutoDetect");
            this.rdAutoDetect.BackColor = System.Drawing.Color.Transparent;
            this.rdAutoDetect.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdAutoDetect.Name = "rdAutoDetect";
            this.rdAutoDetect.TabStop = true;
            this.rdAutoDetect.UseVisualStyleBackColor = false;
            this.rdAutoDetect.CheckedChanged += new System.EventHandler(this.rdAutoDetect_CheckedChanged);
            // 
            // rdSet
            // 
            resources.ApplyResources(this.rdSet, "rdSet");
            this.rdSet.BackColor = System.Drawing.Color.Transparent;
            this.rdSet.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdSet.Name = "rdSet";
            this.rdSet.TabStop = true;
            this.rdSet.UseVisualStyleBackColor = false;
            // 
            // grpProxySettings
            // 
            this.grpProxySettings.BackColor = System.Drawing.Color.Transparent;
            this.grpProxySettings.Controls.Add(this.chkDefaultCredentials);
            this.grpProxySettings.Controls.Add(this.txtProxyPassword);
            this.grpProxySettings.Controls.Add(this.label5);
            this.grpProxySettings.Controls.Add(this.txtProxyUsername);
            this.grpProxySettings.Controls.Add(this.label4);
            this.grpProxySettings.Controls.Add(this.txtProxyPort);
            this.grpProxySettings.Controls.Add(this.label1);
            this.grpProxySettings.Controls.Add(this.txtProxyHost);
            this.grpProxySettings.Controls.Add(this.label2);
            resources.ApplyResources(this.grpProxySettings, "grpProxySettings");
            this.grpProxySettings.Name = "grpProxySettings";
            this.grpProxySettings.TabStop = false;
            // 
            // chkDefaultCredentials
            // 
            resources.ApplyResources(this.chkDefaultCredentials, "chkDefaultCredentials");
            this.chkDefaultCredentials.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkDefaultCredentials.Name = "chkDefaultCredentials";
            this.chkDefaultCredentials.UseVisualStyleBackColor = true;
            this.chkDefaultCredentials.CheckedChanged += new System.EventHandler(this.chkDefaultCredentials_CheckedChanged);
            // 
            // txtProxyPassword
            // 
            resources.ApplyResources(this.txtProxyPassword, "txtProxyPassword");
            this.txtProxyPassword.Name = "txtProxyPassword";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Name = "label5";
            // 
            // txtProxyUsername
            // 
            resources.ApplyResources(this.txtProxyUsername, "txtProxyUsername");
            this.txtProxyUsername.Name = "txtProxyUsername";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Name = "label4";
            // 
            // txtProxyPort
            // 
            resources.ApplyResources(this.txtProxyPort, "txtProxyPort");
            this.txtProxyPort.Name = "txtProxyPort";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Name = "label1";
            // 
            // txtProxyHost
            // 
            resources.ApplyResources(this.txtProxyHost, "txtProxyHost");
            this.txtProxyHost.Name = "txtProxyHost";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Name = "label3";
            // 
            // btnOK
            // 
            this.btnOK.Image = global::BrightnessWheel.Properties.Resources.check;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::BrightnessWheel.Properties.Resources.exit;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmProxySettings
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grpProxySettings);
            this.Controls.Add(this.rdSet);
            this.Controls.Add(this.rdAutoDetect);
            this.Name = "frmProxySettings";
            this.Load += new System.EventHandler(this.frmProxySettings_Load);
            this.grpProxySettings.ResumeLayout(false);
            this.grpProxySettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdAutoDetect;
        private System.Windows.Forms.RadioButton rdSet;
        private System.Windows.Forms.GroupBox grpProxySettings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProxyPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProxyUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProxyPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProxyHost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkDefaultCredentials;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
