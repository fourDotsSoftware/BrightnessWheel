using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Management;
using System.Drawing;
using System.Windows.Forms;

namespace BrightnessWheel
{
    class BrightnessControllerGammaRamp
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("gdi32.dll")]
        private static extern bool GetDeviceGammaRamp(IntPtr hDC, ref ushort lpRamp);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        public static int GetValue = -1;
        public static string CurrentDeviceName = "";

        public static int GetBrightness1()
        {
            return GetValue;

            IntPtr hMonitorDC = GetDC(IntPtr.Zero);
            ushort[] ramp = new ushort[3 * 256];
            bool success = GetDeviceGammaRamp(hMonitorDC, ref ramp[0]);
            ReleaseDC(IntPtr.Zero, hMonitorDC);

            if (success)
            {
                // Brightness level is stored in the green channel

                float f256 = (float)256;
                float f100 = (float)100;
                float fval = (float)ramp[1];

                //fval 256
                // x   100

                return (int)(fval * f100 / f256);

                //return ramp[1];
            }
            else
            {
                Console.WriteLine("Failed to retrieve screen brightness.");
                return -1;
            }
        }        

        [DllImport("gdi32.dll")]
        public static extern bool SetDeviceGammaRamp(IntPtr hdc, ref RampArray ramp);
                
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct RampArray
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public UInt16[] Red;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public UInt16[] Green;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public UInt16[] Blue;
        }

        // The CreateDC function
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CreateDC(
        string lpszDriver,      // Driver name
        string lpszDevice,      // Device name
        string lpszOutput,      // Not used; should be NULL
        IntPtr lpInitData       // Optional printer data
        );

        // Method to set monitor brightness
        public static int SetBrightness1(int brightness)
        {
            Point p = System.Windows.Forms.Cursor.Position;

            Screen screen = Screen.FromPoint(p);

            if (CurrentDeviceName!=screen.DeviceName)
            {
                CurrentDeviceName = screen.DeviceName;

                SetBrightness1(100);

                return 0;
            }

            //3Module.ShowMessage(brightness.ToString());

            // Ensure brightness is within 0-100 range
            brightness = Math.Min(100, Math.Max(0, brightness));

            // Get device context for the entire screen
            //3IntPtr hdc = GetDC(IntPtr.Zero);

            IntPtr hdc=CreateDC(null, screen.DeviceName, null, IntPtr.Zero);

            // Initialize ramp array
            RampArray ramp = new RampArray
            {
                Red = new ushort[256],
                Green = new ushort[256],
                Blue = new ushort[256]
            };

            // Fill ramp array with desired brightness level
            /*
            for (int i = 0; i < 256; i++)
            {
                ramp.Red[i] = ramp.Green[i] = ramp.Blue[i] = (ushort)(65535 * brightness / 100);
            }
            */

            // 255 100
            //  x brigthenss

            float f255 = (float)255;
            float f100 = (float)100;
            float fbr = (float)brightness;

            float fval = fbr * f255 / f100;

            int wBrightness = (int)fval;

            for (int iIndex = 0; iIndex < 256; iIndex++)
            {
                int iArrayValue = iIndex * (wBrightness + 128);

                //int iArrayValue = iIndex * (wBrightness);

                if (iArrayValue > 65535)
                    iArrayValue = 65535;

                ramp.Red[iIndex] =
                ramp.Green[iIndex] =
                ramp.Blue[iIndex] = (ushort)iArrayValue;

            }
            // Set new gamma ramp
            SetDeviceGammaRamp(hdc, ref ramp);

            // Release device context
            ReleaseDC(IntPtr.Zero, hdc);

            GetValue = brightness;

            return 0;
        }

        public static int GetBrightness()
        {
            try
            {
                var mclass = new ManagementClass("WmiMonitorBrightness")
                {
                    Scope = new ManagementScope(@"\\.\root\wmi")
                };
                var instances = mclass.GetInstances();
                foreach (ManagementObject instance in instances)
                {
                    return (byte)instance.GetPropertyValue("CurrentBrightness");
                }

                mclass.Dispose();
                mclass = null;

                instances.Dispose();
                instances = null;


                return 0;
            }
            catch
            {
                return GetBrightness1();
            }
        }

        public static void SetBrightness(int brightness)
        {
            try
            {
                var mclass = new ManagementClass("WmiMonitorBrightnessMethods")
                {
                    Scope = new ManagementScope(@"\\.\root\wmi")
                };
                var instances = mclass.GetInstances();
                var args = new object[] { 1, brightness };
                foreach (ManagementObject instance in instances)
                {
                    instance.InvokeMethod("WmiSetBrightness", args);
                }

                mclass.Dispose();
                mclass = null;

                instances.Dispose();
                instances = null;
            }
            catch
            {
                SetBrightness1(brightness);
            }
        }
    }
}
