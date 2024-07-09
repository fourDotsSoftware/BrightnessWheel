using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


using System.Media;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BrightnessWheel
{
    public partial class ucWheelOption : UserControl
    {        
        public int HotKey = -1;
        public string HotKeyStr = "";

        public bool Control = false;
        public bool Shift = false;
        public bool Alt = false;

        private bool InSpecifyHotKey = false;

        public KeyboardHook keyboardHook = new KeyboardHook();
        public MouseHook mouseHook = null;

        public bool PressedHotKey = false;

        private int OVER_THE_CORNERS_INDEX;
        private int OVER_THE_EDGES_INDEX;
        private int OVER_THE_TOP_BOTTOM_EDGES_INDEX;
        private int OVER_THE_LEFT_RIGHT_EDGES_INDEX;
        private int OVER_THE_TASKBAR;        
        public int DISABLE;

        public OptionEvaluator OptionEvaluator = new OptionEvaluator(0);

        private bool InitializedHotKey = false;

        public bool OverTitleBar = false;

        public int OverTitleBarProcessId = -1;

        public ucWheelOption()
        {
            InitializeComponent();                                  
            
            cmbStep.Items.Add("1");
            cmbStep.Items.Add("5");
            cmbStep.Items.Add("10");
            cmbStep.Items.Add("20");
            cmbStep.Items.Add("30");
            cmbStep.Items.Add("40");
            cmbStep.Items.Add("50");
            cmbStep.Items.Add("60");
            cmbStep.Items.Add("70");
            cmbStep.Items.Add("80");
            cmbStep.Items.Add("100");
            
            cmbStep.SelectedIndex = 2;                       

            cmbOption.Items.Add(TranslateHelper.Translate("Control + Shift Key is pressed"));
            cmbOption.Items.Add(TranslateHelper.Translate("Control + Alt Key is pressed"));
            cmbOption.Items.Add(TranslateHelper.Translate("Shift + Alt Key is pressed"));
            cmbOption.Items.Add(TranslateHelper.Translate("Control Key is pressed"));
            cmbOption.Items.Add(TranslateHelper.Translate("Shift Key is pressed"));
            cmbOption.Items.Add(TranslateHelper.Translate("Alt Key is pressed"));
            cmbOption.Items.Add(TranslateHelper.Translate("Custom Key Combination is pressed"));
            cmbOption.Items.Add(TranslateHelper.Translate("Mouse is at the Edges of Screen"));
            cmbOption.Items.Add(TranslateHelper.Translate("Mouse is at the Top, Bottom Edges of Screen"));
            cmbOption.Items.Add(TranslateHelper.Translate("Mouse is at the Left, Right Edges of Screen"));
            cmbOption.Items.Add(TranslateHelper.Translate("Mouse is at the Corners of Screen"));
            cmbOption.Items.Add(TranslateHelper.Translate("Mouse is above Taskbar"));            
            cmbOption.Items.Add(TranslateHelper.Translate("Mouse is over the Title Bar"));            
            cmbOption.Items.Add(TranslateHelper.Translate("Disable"));

            cmbOption.SelectedIndex = cmbOption.Items.Count - 1;

            mouseHook = new MouseHook(this);

            keyboardHook.KeyDown += KeyboardHook_KeyDown;
            mouseHook.MouseWheel += MouseHook_MouseWheel;
            mouseHook.MouseDown += MouseHook_MouseDown;

            mouseHook.MouseMoveTitleBar += MouseHook_MouseMoveTitleBar;
            mouseHook.MouseLeaveTitleBar += MouseHook_MouseLeaveTitleBar;

        }

        private void MouseHook_MouseLeaveTitleBar(object sender, MouseEventArgs e)
        {
            OverTitleBar = false;
        }

        private void MouseHook_MouseMoveTitleBar(object sender, MouseEventArgs e)
        {
            OverTitleBar = true;
        }

        private void LoadOptions()
        {
            this.Height = cmbOption.Bottom + 5;

            OVER_THE_EDGES_INDEX = 7;
            OVER_THE_TOP_BOTTOM_EDGES_INDEX = 8;
            OVER_THE_LEFT_RIGHT_EDGES_INDEX = 9;
            OVER_THE_CORNERS_INDEX = 10;
            OVER_THE_TASKBAR = 11;            
            DISABLE = 13;

            lblShortcutKeys.Visible = false;
            txtHotKey.Visible = false;
            chkAlt.Visible = false;
            chkControl.Visible = false;
            chkShift.Visible = false;
            btnClearHotKey.Visible = false;
                        
            if (cmbOption.SelectedIndex == 0)
            {
                Control = true;
                Shift = true;
                Alt = false;
                HotKey = -1;
                HotKeyStr = "";
            }
            else if (cmbOption.SelectedIndex == 1)
            {
                Control = true;
                Shift = false;
                Alt = true;
                HotKey = -1;
                HotKeyStr = "";
            }
            else if (cmbOption.SelectedIndex == 2)
            {
                Control = false;
                Shift = true;
                Alt = true;
                HotKey = -1;
                HotKeyStr = "";
            }
            else if (cmbOption.SelectedIndex == 3)
            {
                Control = true;
                Shift = false;
                Alt = false;
                HotKey = -1;
                HotKeyStr = "";
            }
            else if (cmbOption.SelectedIndex == 4)
            {
                Control = false;
                Shift = true;
                Alt = false;
                HotKey = -1;
                HotKeyStr = "";
            }
            else if (cmbOption.SelectedIndex == 5)
            {
                Control = false;
                Shift = false;
                Alt = true;
                HotKey = -1;
                HotKeyStr = "";
            }
            else if (cmbOption.SelectedIndex == 6)
            {
                lblShortcutKeys.Visible = true;
                txtHotKey.Visible = true;
                chkAlt.Visible = true;
                chkControl.Visible = true;
                chkShift.Visible = true;
                btnClearHotKey.Visible = true;

                if (!InitializedHotKey)
                {
                    Control = true;
                    Alt = false;
                    Shift = false;

                    chkControl.Checked = true;
                    chkShift.Checked = false;
                    chkAlt.Checked = false;                    

                    InitializedHotKey = true;
                }

                this.Height = chkShift.Bottom + 5;
            }           
        }

        private void MouseHook_MouseDown(object sender, MouseEventArgs e)
        {
            if (!PressedHotKey) return;
        }

        private void MouseHook_MouseWheel(object sender, MouseEventArgs e)
        {
            bool enable = false;

            bool specificProgram = false;

            if (cmbOption.SelectedIndex == DISABLE)
            {
                return;
            }            
            
            else if (OptionEvaluator.IsOverTheCorners() ||
               OptionEvaluator.IsOverTheEdges() ||
               OptionEvaluator.IsOverTheTaskbar() ||
               OptionEvaluator.IsOverTheTitleBar(this) ||
               OptionEvaluator.IsOverTheTopBottomEdges() ||
               OptionEvaluator.IsOverTheLeftRightEdges() 
               
               )
            {
                enable = true;

                
            }
            else if ((cmbOption.SelectedIndex>=0 && cmbOption.SelectedIndex<=6) && PressedHotKey)
            {
                enable = true;
            }

            if (enable)
            {
                if (e.Delta > 0)
                {
                    IncreaseBrightness();
                }
                else
                {
                    DecreaseBrightness();
                }
            }
        }
        private void KeyboardHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (InSpecifyHotKey) return;

            PressedHotKey = false;

            bool pressed = true;

            if (Control && ((System.Windows.Forms.Control.ModifierKeys & Keys.Control) != Keys.Control))
            {
                pressed = false;

                return;
            }

            if (!Control && ((System.Windows.Forms.Control.ModifierKeys & Keys.Control) == Keys.Control))
            {
                pressed = false;

                return;
            }

            if (Shift && ((System.Windows.Forms.Control.ModifierKeys & Keys.Shift) != Keys.Shift))
            {
                pressed = false;

                return;
            }

            if (!Shift && ((System.Windows.Forms.Control.ModifierKeys & Keys.Shift) == Keys.Shift))
            {
                pressed = false;

                return;
            }

            if (Alt && ((System.Windows.Forms.Control.ModifierKeys & Keys.Alt) != Keys.Alt))
            {
                pressed = false;

                return;
            }

            if (!Alt && ((System.Windows.Forms.Control.ModifierKeys & Keys.Alt) == Keys.Alt))
            {
                pressed = false;

                return;
            }

            if (HotKey != -1)
            {
                if (HotKey == e.KeyValue)
                {
                    PressedHotKey = true;

                    return;
                }
            }
            else
            {
                if (!Control && !Alt && !Shift)
                {
                    PressedHotKey = false;

                    return;
                }

                PressedHotKey = true;


                return;
            }
        }
        //PhysicalMonitorBrightnessController PhysicalMonitorBrightnessController = new PhysicalMonitorBrightnessController();

        private bool Initialized = false;

        //3public BrightnessController2 bcontrol = new BrightnessController2();

        //3private System.ComponentModel.BackgroundWorker bwGet = new System.ComponentModel.BackgroundWorker();
        //3private System.ComponentModel.BackgroundWorker bwSet = new System.ComponentModel.BackgroundWorker();

        private int GetVal = -1;
        private byte SetVal = 0;

        public int Get()
        {
            System.Threading.Thread.Sleep(300);

            if (!Initialized)
            {
                Initialized = true;

                /*3
                bwGet.WorkerReportsProgress = true;
                bwGet.RunWorkerCompleted += BwGet_RunWorkerCompleted;
                bwGet.DoWork += BwGet_DoWork;

                bwSet.WorkerReportsProgress = true;
                bwSet.RunWorkerCompleted += BwSet_RunWorkerCompleted;
                bwSet.DoWork += BwSet_DoWork;*/
            }

            //3bwGet.RunWorkerAsync();
            /*
            while (bwGet.IsBusy)
            {
                Application.DoEvents();
            }
            */

            return BrightnessControllerGammaRamp.GetBrightness();

            //return GetVal;

        }

        public void Set(byte targetBrightness)
        {
            System.Threading.Thread.Sleep(300);

            BrightnessControllerGammaRamp.SetBrightness(targetBrightness);
            /*
            bwSet.RunWorkerAsync(targetBrightness);

            while (bwSet.IsBusy)
            {
                Application.DoEvents();
            }*/
        }


        private void BwSet_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //3SetVal = (byte)e.Argument;
        }

        private void BwSet_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //3bcontrol.SetTask(SetVal);
        }

        private void BwGet_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void BwGet_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //3GetVal = bcontrol.GetTask();
        }

        public void IncreaseBrightness()
        {
            try
            {
                
                if (BrightnessControllerGammaRamp.GetValue == -1)
                {
                    BrightnessControllerGammaRamp.SetBrightness(100);
                }
                

                int step = int.Parse(cmbStep.SelectedItem.ToString());

                //int curval = Get();

                //3int curval = BrightnessController2.Get();

                int curval = BrightnessControllerGammaRamp.GetBrightness();

                int newval = Math.Min(curval + step, 100);

                //Set((byte)newval);

                //3BrightnessController2.Set((byte)newval);

                BrightnessControllerGammaRamp.SetBrightness(newval);

                float newVol = (float)newval;
                float f100 = (float)100;

                if (Properties.Settings.Default.ShowBrightnessBar)
                {
                    Screen screen = Screen.FromPoint(System.Windows.Forms.Cursor.Position);
                    frmVoulme.Instance.Left = screen.Bounds.Width / 2 - frmVoulme.Instance.Width / 2;
                    frmVoulme.Instance.Top = screen.WorkingArea.Height - frmVoulme.Instance.Height - 100;
                    frmVoulme.Instance.Brightness = newVol/f100;
                    frmVoulme.Instance.TopMost = true;
                    frmVoulme.Instance.ShowBrightness();
                }
            }
            catch (Exception ex) {

                Module.ShowError(ex);
            
            }
        }
        public void DecreaseBrightness()
        {
            try
            {
                
                if (BrightnessControllerGammaRamp.GetValue==-1)
                {
                    BrightnessControllerGammaRamp.SetBrightness(100);
                }
                

                int step = int.Parse(cmbStep.SelectedItem.ToString());

                //int curval = Get();
                //3int curval = BrightnessController2.Get();

                int curval = BrightnessControllerGammaRamp.GetBrightness();

                int newval = Math.Max(curval - step, 0);
                                
                //Set((byte)newval);

                //3BrightnessController2.Set((byte)newval);

                BrightnessControllerGammaRamp.SetBrightness(newval);

                float newVol = (float)newval;
                float f100 = (float)100;

                if (Properties.Settings.Default.ShowBrightnessBar)
                {
                    Screen screen = Screen.FromPoint(System.Windows.Forms.Cursor.Position);
                    frmVoulme.Instance.Visible = false;
                    frmVoulme.Instance.Left = screen.Bounds.Width / 2 - frmVoulme.Instance.Width / 2;
                    frmVoulme.Instance.Top = screen.WorkingArea.Height - frmVoulme.Instance.Height - 100;
                    frmVoulme.Instance.Brightness = newVol/f100;
                    frmVoulme.Instance.TopMost = true;
                    frmVoulme.Instance.ShowBrightness();
                }

            }
            catch { }
        }

        bool ProcessExists(uint processId)
        {
            try
            {
                var process = Process.GetProcessById((int)processId);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        private void txtHotKey_KeyDown(object sender, KeyEventArgs e)
        {
            int if13 = (int)Keys.F13;
            int if14 = (int)Keys.F14;
            int if15 = (int)Keys.F15;
            int if16 = (int)Keys.F16;
            int if17 = (int)Keys.F17;

            int vkCode = (int)e.KeyData;

            if ((vkCode == if13) || (vkCode == if14) || (vkCode == if15) || (vkCode == if16) || (vkCode == if17))
            {
                return;
            }

                e.Handled = true;

            Control = e.Control;

            Alt = e.Alt;

            Shift = e.Shift;

            chkControl.Checked = Control;
            chkAlt.Checked = Alt;
            chkShift.Checked = Shift;

            HotKey = -1;
            HotKeyStr = "";


            if (!(e.KeyCode.ToString().Contains("Control") || e.KeyCode.ToString().Contains("Shift") || e.KeyCode.ToString().Contains("Alt") || e.KeyCode.ToString().Contains("Menu")))
            {
                txtHotKey.Text = e.KeyCode.ToString();
                
                HotKey = e.KeyValue;

                HotKeyStr = e.KeyCode.ToString();
            }
            else
            {
                txtHotKey.Text = "";
                HotKey = -1;
                HotKeyStr = "";
            }
        }

        public void cmbOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            OptionEvaluator.ActionIndex = cmbOption.SelectedIndex;

            LoadOptions();
        }                

        private void txtHotKey_Enter(object sender, EventArgs e)
        {
            InSpecifyHotKey = true;
        }

        private void txtHotKey_Leave(object sender, EventArgs e)
        {
            InSpecifyHotKey = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            
        }
        private void ucWheelOption_Load(object sender, EventArgs e)
        {
            
        }

        private void btnClearHotKey_Click(object sender, EventArgs e)
        {
            txtHotKey.Text = "";
            HotKey = -1;
        }
    }
}

