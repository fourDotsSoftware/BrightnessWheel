namespace BrightnessWheel
{
    partial class frmOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptions));
            this.label3 = new System.Windows.Forms.Label();
            this.chkBrightnessBar = new System.Windows.Forms.CheckBox();
            this.btnBrightnessBarColorFrom = new System.Windows.Forms.Button();
            this.btnBrightnessBarColorTo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrightnessBarNumbersColor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkBrightnessValueNumbers = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Name = "label3";
            // 
            // chkBrightnessBar
            // 
            resources.ApplyResources(this.chkBrightnessBar, "chkBrightnessBar");
            this.chkBrightnessBar.BackColor = System.Drawing.Color.Transparent;
            this.chkBrightnessBar.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkBrightnessBar.Name = "chkBrightnessBar";
            this.chkBrightnessBar.UseVisualStyleBackColor = false;
            // 
            // btnBrightnessBarColorFrom
            // 
            this.btnBrightnessBarColorFrom.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnBrightnessBarColorFrom, "btnBrightnessBarColorFrom");
            this.btnBrightnessBarColorFrom.Name = "btnBrightnessBarColorFrom";
            this.btnBrightnessBarColorFrom.UseVisualStyleBackColor = true;
            this.btnBrightnessBarColorFrom.Click += new System.EventHandler(this.btnBrightnessBarColorFrom_Click);
            // 
            // btnBrightnessBarColorTo
            // 
            this.btnBrightnessBarColorTo.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnBrightnessBarColorTo, "btnBrightnessBarColorTo");
            this.btnBrightnessBarColorTo.Name = "btnBrightnessBarColorTo";
            this.btnBrightnessBarColorTo.UseVisualStyleBackColor = true;
            this.btnBrightnessBarColorTo.Click += new System.EventHandler(this.btnBrightnessBarColorFrom_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Name = "label1";
            // 
            // btnBrightnessBarNumbersColor
            // 
            this.btnBrightnessBarNumbersColor.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnBrightnessBarNumbersColor, "btnBrightnessBarNumbersColor");
            this.btnBrightnessBarNumbersColor.Name = "btnBrightnessBarNumbersColor";
            this.btnBrightnessBarNumbersColor.UseVisualStyleBackColor = true;
            this.btnBrightnessBarNumbersColor.Click += new System.EventHandler(this.btnBrightnessBarColorFrom_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Name = "label2";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Image = global::BrightnessWheel.Properties.Resources.check;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Image = global::BrightnessWheel.Properties.Resources.exit;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkBrightnessValueNumbers
            // 
            resources.ApplyResources(this.chkBrightnessValueNumbers, "chkBrightnessValueNumbers");
            this.chkBrightnessValueNumbers.BackColor = System.Drawing.Color.Transparent;
            this.chkBrightnessValueNumbers.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkBrightnessValueNumbers.Name = "chkBrightnessValueNumbers";
            this.chkBrightnessValueNumbers.UseVisualStyleBackColor = false;
            // 
            // frmOptions
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.chkBrightnessValueNumbers);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnBrightnessBarNumbersColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrightnessBarColorTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrightnessBarColorFrom);
            this.Controls.Add(this.chkBrightnessBar);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOptions";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkBrightnessBar;
        private System.Windows.Forms.Button btnBrightnessBarColorFrom;
        private System.Windows.Forms.Button btnBrightnessBarColorTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrightnessBarNumbersColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkBrightnessValueNumbers;
    }
}
