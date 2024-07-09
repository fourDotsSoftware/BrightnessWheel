using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BrightnessWheel
{
    public partial class frmMessageCheckbox : CustomForm
    {
        public enum MessageType
        {
            None,
            MsgMinimized,
            MsgFirstTime
        }

        private MessageType _MessageType = frmMessageCheckbox.MessageType.None;

        public frmMessageCheckbox()
        {
            InitializeComponent();
        }

        public frmMessageCheckbox(string title,string lblDesc):this(title,lblDesc,"",MessageType.None)
        {

        }

        public frmMessageCheckbox(string title,string lblDesc,string chkDesc,MessageType msgtype)
        {
            InitializeComponent();

            lblAppName.Text = Module.ApplicationName;

            lblAppName.Left = this.Width / 2 - lblAppName.Width / 2;

            this.Text = title;

            this.lblOption.Text = lblDesc;

            if (chkDesc != String.Empty)
            {
                this.chkOption.Text = chkDesc;
            }

            _MessageType = msgtype;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {           
            if (chkOption.Checked)
            {
                if (_MessageType==MessageType.MsgMinimized)
                {
                    Properties.Settings.Default.MsgMinimized = false;

                    Properties.Settings.Default.Save();
                }

                this.DialogResult = DialogResult.Yes;
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }

            this.Close();
        }        
        private void frmMessageCheckbox_Load(object sender, EventArgs e)
        {
            /*
            lblOption.Text =
TranslateHelper.Translate("The first time you run the application this settings window is being shown.\n\nHowever, next times the application will run hidden, minimized to the Windows system tray and you can access the Settings window by doing a right click and selecting Open from the menu.\n\n You can also uncheck the option [Minimize to System Tray].");

            this.Text = TranslateHelper.Translate("Warning");
            */
        }
    }
}

