namespace BrightnessWheel
{
    partial class frmVoulme
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
            this.lblMin = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.BackColor = System.Drawing.Color.Transparent;
            this.lblMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblMin.ForeColor = System.Drawing.Color.LightGreen;
            this.lblMin.Location = new System.Drawing.Point(23, 23);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(40, 42);
            this.lblMin.TabIndex = 0;
            this.lblMin.Text = "0";
            this.lblMin.Visible = false;
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.BackColor = System.Drawing.Color.Transparent;
            this.lblMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblMax.ForeColor = System.Drawing.Color.LightGreen;
            this.lblMax.Location = new System.Drawing.Point(804, 23);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(84, 42);
            this.lblMax.TabIndex = 1;
            this.lblMax.Text = "100";
            this.lblMax.Visible = false;
            // 
            // frmVoulme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(900, 88);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblMin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVoulme";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.TransparencyKey = System.Drawing.Color.DarkSlateBlue;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblMax;
    }
}