using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace BrightnessWheel
{
    public partial class frmVoulme : Form
    {
        public static frmVoulme Instance = new frmVoulme();
        private Timer timerShow = new Timer();
        private int TickCount = 0;

        public frmVoulme()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            Instance = this;

            //3timerShow.Interval = 4 * 1000;
            timerShow.Interval = 100;
            timerShow.Tick += TimerShow_Tick;

            this.BackColor = Color.DarkSlateBlue;
            this.TransparencyKey = Color.DarkSlateBlue;

            Screen screen = Screen.FromControl(this);
            frmVoulme.Instance.Visible = false;
            frmVoulme.Instance.Left = screen.Bounds.Width / 2 - frmVoulme.Instance.Width / 2;
            frmVoulme.Instance.Top = screen.WorkingArea.Height - frmVoulme.Instance.Height - 100;
                        
        }

        private void TimerShow_Tick(object sender, EventArgs e)
        {
            TickCount++;
            /*
            if (TickCount<=10)
            {
                float f10 = (float)10;
                float ftick = (float)TickCount;
                float f100 = (float)100;

                //Opacity = (10 * TickCount) / 100;

                Opacity = (f10 * ftick) / f100;
            }
            else if (TickCount>10 && TickCount<=40)
            {

            }*/

            if (TickCount>=0 && TickCount<=20)
            {
                Opacity = 1;
            }
            else if (TickCount>20 && TickCount<=30)
            {
                float f10 = (float)10;
                float ftick = (float)TickCount;
                float f100 = (float)100;
                float f20 = (float)20;
                //Opacity = (100 - (TickCount - 20) * 10) / 100;

                Opacity = (f100 - (ftick - f20) * f10) / f100;
            }
            
            if (TickCount==30)
            {
                TickCount = 0;
                timerShow.Enabled = false;
                TopMost = false;
            }
            /*
            this.Hide();

            timerShow.Enabled = false;
            */
        }

        public float Brightness = 0;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // 1  xmax-xmin
            // vol  x;

            int StartPositionX = lblMin.Right + 12;
            int EndPositionX = lblMax.Left - 12;

            int volTop = lblMin.Top - 5;
            int volBottom = lblMin.Bottom + 5;

            float fmax = (float)(EndPositionX - StartPositionX);

            float fwidth = Brightness * fmax;

            int iwidth = (int)fwidth;

            int vol = (int)(Brightness * 100);

            lblMax.Text = vol.ToString();

            e.Graphics.Clear(System.Drawing.Color.DarkSlateBlue);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            LinearGradientBrush linGrBrush = new LinearGradientBrush(
                new Point(0, this.Height), new Point(0, 0),

                //new Rectangle(Math.Min(StartSelectionX, EndSelectionX), 0,
                //  Math.Max(1,Math.Abs(EndSelectionX - StartSelectionX)), Math.Max(1,this.Height)),
                //Color.FromArgb(255, 0, 0, 0),     // Opaque black 

                //Color.FromArgb(255, 255, 255, 0),     // Opaque black 
                Properties.Settings.Default.BrightnessColorTo,
            //System.Drawing.Color.LightGreen);
            Properties.Settings.Default.BrightnessColorFrom);

            float[] relativeIntensities = { 1.0f, 0.5f, 1.0f };
            float[] relativePositions = { 0.0f, 0.5f, 1.0f };

            //Create a Blend object and assign it to linGrBrush.
            Blend blend = new Blend();
            blend.Factors = relativeIntensities;
            blend.Positions = relativePositions;
            linGrBrush.Blend = blend;

            e.Graphics.FillRectangle(linGrBrush,
                //e.Graphics.FillRectangle(System.Drawing.Brushes.LightGreen,
                new System.Drawing.Rectangle(StartPositionX,volTop,iwidth,volBottom-volTop));                                             

            linGrBrush.Dispose();
            linGrBrush = null;

            blend = null;

            if (Properties.Settings.Default.ShowBrightnessValues)
            {
                DrawMin(e.Graphics, "0");
                DrawCurrent(e.Graphics, vol.ToString());
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void ShowBrightness()
        {
            TickCount = 0;
            Opacity = 1;
            timerShow.Enabled = true;
            this.Show();
            this.Invalidate();
            this.BringToFront();


        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DarkSlateBlue, e.ClipRectangle);
        }

        public void DrawDoubleColorText(System.Drawing.Graphics g, string text, Point p, Font font, FontStyle fontStyle)
        {
            StringFormat strformat = new StringFormat();

            string szbuf = text;

            GraphicsPath path = new GraphicsPath();
            path.AddString(szbuf, font.FontFamily,
            Convert.ToInt32(fontStyle), font.Size, p, strformat);

            Pen pen = new Pen(Color.Black, 6);
            pen.LineJoin = LineJoin.Round;
            g.DrawPath(pen, path);

            //SolidBrush brush = new SolidBrush(Color.LightGreen);
            SolidBrush brush = new SolidBrush(Properties.Settings.Default.BrightnessColorNumbers);
            g.FillPath(brush, path);

            path.Dispose();
            pen.Dispose();
            brush.Dispose();
            strformat.Dispose();

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        public void DrawMin(System.Drawing.Graphics g, string text)
        {
            DrawDoubleColorText(g, text, lblMin.Location, lblMin.Font, FontStyle.Bold);
        }

        public void DrawCurrent(System.Drawing.Graphics g, string text)
        {
            DrawDoubleColorText(g, text, lblMax.Location, lblMin.Font, FontStyle.Bold);
        }

    }
}
