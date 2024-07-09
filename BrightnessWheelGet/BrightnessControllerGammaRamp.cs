using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace BrightnessWheelGet
{
    class BrightnessControllerGammaRamp
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("gdi32.dll")]
        private static extern bool GetDeviceGammaRamp(IntPtr hDC, ref ushort lpRamp);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        public static int GetBrightness()
        {
            IntPtr hMonitorDC = GetDC(IntPtr.Zero);
            ushort[] ramp = new ushort[3 * 256];
            bool success = GetDeviceGammaRamp(hMonitorDC, ref ramp[0]);
            ReleaseDC(IntPtr.Zero, hMonitorDC);

            if (success)
            {
                // Brightness level is stored in the green channel
                return ramp[1];
            }
            else
            {
                Console.WriteLine("Failed to retrieve screen brightness.");
                return -1;
            }
        }
    }
}
