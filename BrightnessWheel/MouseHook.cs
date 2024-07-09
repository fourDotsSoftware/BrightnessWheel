using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BrightnessWheel
{

    /// <summary>
    /// Captures global mouse events
    /// </summary>
    public class MouseHook : GlobalHook
    {

        #region MouseEventType Enum

        private enum MouseEventType
        {
            None,
            MouseDown,
            MouseUp,
            DoubleClick,
            MouseWheel,
            MouseMove,
            MoveTitleBar,
            LeaveTitleBar,
            HitTest
        }

        #endregion

        #region Events

        public event MouseEventHandler MouseDown;
        public event MouseEventHandler MouseUp;
        public event MouseEventHandler MouseMove;
        public event MouseEventHandler MouseWheel;
        public event MouseEventHandler MouseMoveTitleBar;
        public event MouseEventHandler MouseLeaveTitleBar;
        public event EventHandler Click;
        public event EventHandler DoubleClick;

        #endregion

        #region Constructor

        private ucWheelOption WheelOption = null;

        public static bool CheckSetHookTimer = false;

        public MouseHook(ucWheelOption wheelOption)
        {

            _hookType = WH_MOUSE_LL;            

            WheelOption = wheelOption;
        }

        #endregion

        #region Methods

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        /*
        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);*/

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);


        [DllImport("user32.dll")]
        static extern IntPtr WindowFromPoint(System.Drawing.Point p);

        public int MakeLParam(int LoWord, int HiWord)
        {
            return HiWord << 16 | LoWord & 0xFFFF;
        }

        private int count=0;
        protected override int HookCallbackProcedure(int nCode, int wParam, IntPtr lParam)
        {                        
            if (nCode > -1 && (MouseDown != null || MouseUp != null || MouseMove != null))
            {
                MouseHook.CheckSetHookTimer = false;

                MouseLLHookStruct mouseHookStruct =
                    (MouseLLHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseLLHookStruct));
                
                MouseButtons button = GetButton(wParam);
                MouseEventType eventType = GetEventType(wParam);

                MouseEventArgs e = new MouseEventArgs(
                    button,
                    (eventType == MouseEventType.DoubleClick ? 2 : 1),
                    mouseHookStruct.pt.x,
                    mouseHookStruct.pt.y,
                    (eventType == MouseEventType.MouseWheel ? (short)((mouseHookStruct.mouseData >> 16) & 0xffff) : 0));

                // Prevent multiple Right Click events (this probably happens for popup menus)
                if (button == MouseButtons.Right && mouseHookStruct.flags != 0)
                {
                    eventType = MouseEventType.None;
                }

                switch (eventType)
                {
                    case MouseEventType.MouseDown:
                        if (MouseDown != null)
                        {
                            MouseDown(this, e);
                        }
                        break;
                    case MouseEventType.MouseUp:
                        if (Click != null)
                        {
                            Click(this, new EventArgs());
                        }
                        if (MouseUp != null)
                        {
                            MouseUp(this, e);
                        }
                        break;
                    case MouseEventType.DoubleClick:
                        if (DoubleClick != null)
                        {
                            DoubleClick(this, new EventArgs());
                        }
                        break;
                    case MouseEventType.MouseWheel:
                        if (MouseWheel != null)
                        {
                            MouseWheel(this, e);
                        }

                        if (WheelOption.cmbOption.SelectedIndex==WheelOption.DISABLE)
                        {
                            return CallNextHookEx(_handleToHook, nCode, wParam, lParam);
                        }
                        //for (int k = 0; k < frmMain.Instance.WheelOptions.Count; k++)
                        //{
                        //ucWheelOption WheelOption = frmMain.Instance.WheelOptions[k];                            

                        
                        else if (WheelOption.OptionEvaluator.IsHotKey(WheelOption))
                        //if (WheelOption.PressedHotKey)
                        {
                            return 1;
                        }
                        else if (WheelOption.OptionEvaluator.IsOverTheCorners() ||
                            WheelOption.OptionEvaluator.IsOverTheEdges() ||
                            WheelOption.OptionEvaluator.IsOverTheTitleBar(WheelOption) ||
                            WheelOption.OptionEvaluator.IsOverTheTaskbar() ||
                            WheelOption.OptionEvaluator.IsOverTheTopBottomEdges() ||
                            WheelOption.OptionEvaluator.IsOverTheLeftRightEdges() 
                            )
                            
                        {
                            return 1;
                        }
                        //}

                        break;
                    case MouseEventType.MouseMove:
                        if (MouseMove != null)
                        {
                            MouseMove(this, e);
                        }

                        IntPtr hwnd = GetForegroundWindow();

                        IntPtr res = SendMessage(hwnd, (uint)WM_NCHITTEST, 0,
                            new IntPtr(MakeLParam(System.Windows.Forms.Cursor.Position.X, System.Windows.Forms.Cursor.Position.Y)));

                        int ires = res.ToInt32();

                        WheelOption.OverTitleBar = (ires == (int)(GetHitTestValues.HitTestValues.HTCAPTION));

                        if (WheelOption.OverTitleBar)
                        {
                            IntPtr windowHwnd = WindowFromPoint(System.Windows.Forms.Cursor.Position);

                            uint procid;

                            GetWindowThreadProcessId(windowHwnd, out procid);

                            WheelOption.OverTitleBarProcessId = (int)procid;
                        }
                        else
                        {
                            WheelOption.OverTitleBarProcessId = -1;
                        }

                        break;
                    case MouseEventType.MoveTitleBar:
                        if (MouseMoveTitleBar != null)
                        {
                            MouseMoveTitleBar(this, e);
                        }
                        break;
                    case MouseEventType.LeaveTitleBar:
                        if (MouseLeaveTitleBar != null)
                        {
                            MouseLeaveTitleBar(this, e);
                        }
                        break;
                    default:
                        break;
                }

            }

            return CallNextHookEx(_handleToHook, nCode, wParam, lParam);

        }

        private MouseButtons GetButton(Int32 wParam)
        {

            switch (wParam)
            {

                case WM_LBUTTONDOWN:
                case WM_LBUTTONUP:
                case WM_LBUTTONDBLCLK:
                    return MouseButtons.Left;
                case WM_RBUTTONDOWN:
                case WM_RBUTTONUP:
                case WM_RBUTTONDBLCLK:
                    return MouseButtons.Right;
                case WM_MBUTTONDOWN:
                case WM_MBUTTONUP:
                case WM_MBUTTONDBLCLK:
                    return MouseButtons.Middle;
                default:
                    return MouseButtons.None;

            }

        }

        private MouseEventType GetEventType(Int32 wParam)
        {

            switch (wParam)
            {

                case WM_LBUTTONDOWN:
                case WM_RBUTTONDOWN:
                case WM_MBUTTONDOWN:
                    return MouseEventType.MouseDown;
                case WM_LBUTTONUP:
                case WM_RBUTTONUP:
                case WM_MBUTTONUP:
                    return MouseEventType.MouseUp;
                case WM_LBUTTONDBLCLK:
                case WM_RBUTTONDBLCLK:
                case WM_MBUTTONDBLCLK:
                    return MouseEventType.DoubleClick;
                case WM_MOUSEWHEEL:
                    return MouseEventType.MouseWheel;
                case WM_MOUSEMOVE:
                    return MouseEventType.MouseMove;
                case WM_NCHITTEST:
                    
                    return MouseEventType.None;
                case WM_NCMOUSEMOVE:
                    return MouseEventType.MoveTitleBar;
                case WM_NCMOUSELEAVE:
                    return MouseEventType.LeaveTitleBar;
                case WM_NCLBUTTONDOWN:
                    
                    return MouseEventType.None;
                
                default:
                    return MouseEventType.None;

            }
        }

        #endregion
        
    }

}
