namespace BrightnessWheel
{
    partial class frmDownloadUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDownloadUpdate));
            this.pgBar = new BrightnessWheel.ucTextProgressBar();
            this.btnCancelDownload = new System.Windows.Forms.Button();
            this.bwDownload = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalSize = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ulDownloadFile = new BrightnessWheel.URLLinkLabel();
            this.btnProxy = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pgBar
            // 
            this.pgBar.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.pgBar, "pgBar");
            this.pgBar.Name = "pgBar";
            // 
            // btnCancelDownload
            // 
            resources.ApplyResources(this.btnCancelDownload, "btnCancelDownload");
            this.btnCancelDownload.Name = "btnCancelDownload";
            this.btnCancelDownload.UseVisualStyleBackColor = true;
            this.btnCancelDownload.Click += new System.EventHandler(this.btnCancelDownload_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Name = "label1";
            // 
            // lblTotalSize
            // 
            resources.ApplyResources(this.lblTotalSize, "lblTotalSize");
            this.lblTotalSize.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalSize.Name = "lblTotalSize";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Name = "label2";
            // 
            // ulDownloadFile
            // 
            resources.ApplyResources(this.ulDownloadFile, "ulDownloadFile");
            this.ulDownloadFile.Name = "ulDownloadFile";
            this.ulDownloadFile.TabStop = true;
            // 
            // btnProxy
            // 
            resources.ApplyResources(this.btnProxy, "btnProxy");
            this.btnProxy.Name = "btnProxy";
            this.btnProxy.UseVisualStyleBackColor = true;
            this.btnProxy.Click += new System.EventHandler(this.btnProxy_Click);
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Image = global::BrightnessWheel.Properties.Resources.exit;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Name = "label3";
            // 
            // btnCopy
            // 
            this.btnCopy.Image = global::BrightnessWheel.Properties.Resources.copy;
            resources.ApplyResources(this.btnCopy, "btnCopy");
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // frmDownloadUpdate
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnProxy);
            this.Controls.Add(this.ulDownloadFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotalSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelDownload);
            this.Controls.Add(this.pgBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDownloadUpdate";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDownloadUpdate_FormClosing);
            this.Load += new System.EventHandler(this.frmDownloadUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucTextProgressBar pgBar;
        private System.Windows.Forms.Button btnCancelDownload;
        private System.ComponentModel.BackgroundWorker bwDownload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalSize;
        private System.Windows.Forms.Label label2;
        private URLLinkLabel ulDownloadFile;
        private System.Windows.Forms.Button btnProxy;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCopy;
    }
}
