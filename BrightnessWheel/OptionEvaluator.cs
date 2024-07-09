using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace BrightnessWheel
{
    public class OptionEvaluator
    {
        public int ActionIndex=-1;

        private const int OVER_THE_EDGES_INDEX = 7;
        private const int OVER_THE_TOP_BOTTOM_EDGES_INDEX = 8;
        private const int OVER_THE_LEFT_RIGHT_EDGES_INDEX= 9;
        private const int OVER_THE_CORNERS_INDEX = 10;
        private const int OVER_THE_TASKBAR = 11;        
        private const int OVER_TITLEBAR = 12;
        

        public int LastSpecificProgramProcessId = -1;
        public OptionEvaluator(int actionIndex)
        {
            ActionIndex = actionIndex;
        }

        public bool IsOverTheCorners()
        {
            if (ActionIndex != OVER_THE_CORNERS_INDEX)
            {
                return false;
            }

            Point p = System.Windows.Forms.Cursor.Position;

            Screen screen = Screen.FromPoint(p);

            int offset = 15;

            if (((p.X >= screen.Bounds.Left) && (p.X <= (screen.Bounds.Left + offset))) &&
                ((p.Y >= screen.Bounds.Top) && (p.Y <= (screen.Bounds.Top + offset))))
            {
                return true;
            }
            else if (((p.X >= screen.Bounds.Left) && (p.X <= (screen.Bounds.Left + offset))) &&
                ((p.Y <= screen.Bounds.Bottom) && (p.Y >= (screen.Bounds.Bottom - offset))))
            {
                return true;
            }
            if (((p.X <= screen.Bounds.Right) && (p.X >= (screen.Bounds.Right - offset))) &&
                ((p.Y >= screen.Bounds.Top) && (p.Y <= (screen.Bounds.Top + offset))))
            {
                return true;
            }
            if (((p.X <= screen.Bounds.Right) && (p.X >= (screen.Bounds.Right - offset))) &&
                ((p.Y <= screen.Bounds.Bottom) && (p.Y >= (screen.Bounds.Bottom - offset))))
            {
                return true;
            }

            return false;
        }
        /*
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
            cmbOption.Items.Add(TranslateHelper.Translate("Specific Program is focused"));
            cmbOption.Items.Add(TranslateHelper.Translate("Specific Program is focused and Hot Key is pressed"));
            cmbOption.Items.Add(TranslateHelper.Translate("Disable"));
         */
        public bool IsHotKey(ucWheelOption wheelOption)
        {
            if ((ActionIndex==0) || (ActionIndex == 1) || (ActionIndex == 2) || (ActionIndex == 3) ||
                (ActionIndex == 4) || (ActionIndex == 5) || (ActionIndex == 6))
            {
                return (wheelOption.PressedHotKey);
            }
            else
            {
                return false;
            }
        }
        public bool IsOverTheEdges()
        {
            if (ActionIndex != OVER_THE_EDGES_INDEX)
            {
                return false;
            }

            Point p = System.Windows.Forms.Cursor.Position;

            Screen screen = Screen.FromPoint(p);

            int offset = 5;

            //if (((p.X >= screen.Bounds.Left) && (p.X <= (screen.Bounds.Left + offset))))
            if (p.X == screen.Bounds.Left)
            {
                return true;
            }
            else if ((p.Y <= screen.Bounds.Bottom) && (p.Y >= (screen.Bounds.Bottom - offset)))
            {
                return true;
            }
            //else if (p.X == screen.Bounds.Right)
            else if ((p.X <= screen.Bounds.Right) && (p.X >= (screen.Bounds.Right - offset)))
            {
                return true;
            }
            else if ((p.Y >= screen.Bounds.Top) && (p.Y <= (screen.Bounds.Top + offset)))
            {
                return true;
            }

            return false;
        }

        public bool IsOverTheTopBottomEdges()
        {
            if (ActionIndex != OVER_THE_TOP_BOTTOM_EDGES_INDEX)
            {
                return false;
            }

            Point p = System.Windows.Forms.Cursor.Position;

            Screen screen = Screen.FromPoint(p);

            int offset = 5;

            if ((p.Y <= screen.Bounds.Bottom) && (p.Y >= (screen.Bounds.Bottom - offset)))
            {
                return true;
            }
            else if ((p.Y >= screen.Bounds.Top) && (p.Y <= (screen.Bounds.Top + offset)))
            {
                return true;
            }                        

            return false;
        }

        public bool IsOverTheLeftRightEdges()
        {
            if (ActionIndex != OVER_THE_LEFT_RIGHT_EDGES_INDEX)
            {
                return false;
            }

            Point p = System.Windows.Forms.Cursor.Position;

            Screen screen = Screen.FromPoint(p);

            int offset = 5;

            //if (((p.X >= screen.Bounds.Left) && (p.X <= (screen.Bounds.Left + offset))))
            if (p.X == screen.Bounds.Left)
            {
                return true;
            }            
            else if ((p.X <= screen.Bounds.Right) && (p.X >= (screen.Bounds.Right - offset)))
            {
                return true;
            }            

            return false;
        }

        public bool IsOverTheTitleBar(ucWheelOption wheelOption)
        {
            if ((ActionIndex != OVER_TITLEBAR))
            {
                return false;
            }

            return (wheelOption.OverTitleBar);
        }
        
        public bool IsOverTheTaskbar()
        {
            if (ActionIndex != OVER_THE_TASKBAR)
            {
                return false;
            }

            Point p = System.Windows.Forms.Cursor.Position;

            Screen sc = Screen.FromPoint(p);

            int tasktop = 0;
            int taskbottom = 0;
            int taskleft = 0;
            int taskright = 0;

            if (sc.WorkingArea.Top > 0)
            {
                // TASKBAR TOP

                taskbottom = sc.WorkingArea.Top;
                tasktop = 0;
                taskleft = 0;
                taskright = sc.Bounds.Right;
            }
            else if (sc.WorkingArea.Left != sc.Bounds.X)
            {
                // TASKBAR LEFT

                taskleft = 0;
                taskright = sc.WorkingArea.Left;
                tasktop = 0;
                taskbottom = sc.Bounds.Height;

            }
            else if ((sc.Bounds.Height - sc.WorkingArea.Height) > 0)
            {
                // TASKBAR BOTTOM

                taskleft = 0;
                taskright = sc.Bounds.Width;
                tasktop = sc.WorkingArea.Bottom;
                taskbottom = sc.Bounds.Bottom;
            }
            else  if (sc.WorkingArea.Right != 0)
            {
                // TASKBAR RIGHT

                taskleft = sc.WorkingArea.Left;
                taskright = sc.Bounds.Width;
                tasktop = 0;
                taskbottom = sc.Bounds.Bottom;
            }

            Rectangle r = new Rectangle(taskleft, tasktop, taskright - taskleft, taskbottom - tasktop);

            if (r.Contains(p))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();        
    }
}
