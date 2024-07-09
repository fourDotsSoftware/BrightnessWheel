using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace BrightnessWheelSet
{
    class BrightnessControllerGammaRamp
    {
        // Define necessary WinAPI functions and structures
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("gdi32.dll")]
        public static extern bool SetDeviceGammaRamp(IntPtr hdc, ref RampArray ramp);

        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

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

        // Method to set monitor brightness
        public static int SetBrightness(int brightness)
        {
            // Ensure brightness is within 0-100 range
            brightness = Math.Min(100, Math.Max(0, brightness));

            // Get device context for the entire screen
            IntPtr hdc = GetDC(IntPtr.Zero);

            // Initialize ramp array
            RampArray ramp = new RampArray
            {
                Red = new ushort[256],
                Green = new ushort[256],
                Blue = new ushort[256]
            };

            // Fill ramp array with desired brightness level
            for (int i = 0; i < 256; i++)
            {
                ramp.Red[i] = ramp.Green[i] = ramp.Blue[i] = (ushort)(65535 * brightness / 100);
            }

            // Set new gamma ramp
            SetDeviceGammaRamp(hdc, ref ramp);

            // Release device context
            ReleaseDC(IntPtr.Zero, hdc);

            return 0;
        }
    }
}
