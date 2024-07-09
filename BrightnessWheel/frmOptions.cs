using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BrightnessWheel
{
    public partial class frmOptions : BrightnessWheel.CustomForm
    {
        public frmOptions()
        {
            InitializeComponent();
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            chkBrightnessBar.Checked = Properties.Settings.Default.ShowBrightnessBar;

            btnBrightnessBarColorFrom.BackColor = Properties.Settings.Default.BrightnessColorFrom;

            btnBrightnessBarColorTo.BackColor = Properties.Settings.Default.BrightnessColorTo;

            btnBrightnessBarNumbersColor.BackColor = Properties.Settings.Default.BrightnessColorNumbers;

            chkBrightnessValueNumbers.Checked = Properties.Settings.Default.ShowBrightnessValues;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowBrightnessBar = chkBrightnessBar.Checked;

            Properties.Settings.Default.BrightnessColorFrom = btnBrightnessBarColorFrom.BackColor;

            Properties.Settings.Default.BrightnessColorTo = btnBrightnessBarColorTo.BackColor;

            Properties.Settings.Default.BrightnessColorNumbers = btnBrightnessBarNumbersColor.BackColor;

            Properties.Settings.Default.ShowBrightnessValues = chkBrightnessValueNumbers.Checked;

            this.DialogResult = DialogResult.OK;
        }

        private void btnBrightnessBarColorFrom_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            cd.FullOpen = true;

            if (sender==btnBrightnessBarColorFrom)
            {
                cd.Color = btnBrightnessBarColorFrom.BackColor;
            }
            else if (sender==btnBrightnessBarColorTo)
            {
                cd.Color = btnBrightnessBarColorTo.BackColor;
            }
            else if (sender==btnBrightnessBarNumbersColor)
            {
                cd.Color = btnBrightnessBarNumbersColor.BackColor;
            }

            if (cd.ShowDialog()==DialogResult.OK)
            {
                if (sender == btnBrightnessBarColorFrom)
                {
                    btnBrightnessBarColorFrom.BackColor = cd.Color;
                }
                else if (sender == btnBrightnessBarColorTo)
                {
                    btnBrightnessBarColorTo.BackColor = cd.Color;
                }
                else if (sender == btnBrightnessBarNumbersColor)
                {
                    btnBrightnessBarNumbersColor.BackColor = cd.Color;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
