using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;

namespace BrightnessWheel
{
	static class Display
	{
		[DllImport("gdi32.dll")]
		private unsafe static extern bool SetDeviceGammaRamp(Int32 hdc, void* ramp);

		private static bool initialized = false;
		private static Int32 hdc;

		private static double[] _gammas = { 1, 1, 1 };
		private static short _brightness = 100;

		private static void InitializeClass()
		{
			if (initialized)
				return;

			//Get the hardware device context of the screen, we can do
			//this by getting the graphics object of null (IntPtr.Zero)
			//then getting the HDC and converting that to an Int32.
			hdc = Graphics.FromHwnd(IntPtr.Zero).GetHdc().ToInt32();

			initialized = true;
		}

		public static bool SetGamma(double gammaRed, double gammaGreen, double gammaBlue)
		{
			_gammas[0] = gammaRed;
			_gammas[1] = gammaGreen;
			_gammas[2] = gammaBlue;

			return UpdateRamps();
		}

		public static bool SetBrightness(short brightness)
		{
			if (brightness > 100)
				brightness = 100;

			if (brightness < 0)
				brightness = 0;

			_brightness = brightness;

			return UpdateRamps();
		}

		private static unsafe bool UpdateRamps()
		{
			InitializeClass();

			double brightness = (double)_brightness / 100f;

			ushort* gArray = stackalloc ushort[3 * 256];
			ushort* idx = gArray;

			for (int j = 0; j < 3; j++)
			{
				for (int i = 0; i < 256; i++)
				{
					double arrayVal;
					// gamma calculation
					arrayVal = (Math.Pow((double)i / 256.0, 1.0 / _gammas[j]) * 65535) + 0.5;
					arrayVal *= brightness;

					if (arrayVal > 65535)
						arrayVal = 65535;
					if (arrayVal < 0)
						arrayVal = 0;

					*idx = (ushort)arrayVal;
					idx++;
				}
			}

			bool retVal = SetDeviceGammaRamp(hdc, gArray);

			//Memory allocated through stackalloc is automatically free'd
			//by the CLR.

			return retVal;
		}
	}
}
