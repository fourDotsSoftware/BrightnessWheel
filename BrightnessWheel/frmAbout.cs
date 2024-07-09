using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BrightnessWheel
{
    public partial class frmAbout : CustomForm
    {
        public static string lblf = "";

        public static string[] bufluf = new string[5];
        public static List<string> lstbufluf = new List<string>();

        // license email
        public static string LDT = "";

        public frmAbout()
        {
            InitializeComponent();
        }
                     
        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblAbout.Text = Module.ApplicationTitle + "\n\n" +
            "Developed by Alexander Triantafyllou\n" +
            "Copyright © 2022 - softpcapps Software\n";                       
            
            ullProductWebpage.Text = Module.ProductWebpageURL;

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnDonate_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://softpcapps.com/donate.php");
        }
    }
}