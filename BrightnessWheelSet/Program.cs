using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace BrightnessWheelSet
{
    class Program
    {
        static int Main(string[] args)
        {
            int option = int.Parse(args[0]);

            if (option == 0)
            {
                byte brightness = byte.Parse(args[1]);

                int suc = SetTask(brightness);

                return suc;
            }
            else
            {
                //PhysicalMonitorBrightnessController pr = new PhysicalMonitorBrightnessController();

                uint newval = uint.Parse(args[1]);

                //pr.Set(newval);

                try
                {
                    BrightnessController bcon = new BrightnessController();
                    bcon.SetBrightness((int)newval);

                }
                catch
                {
                    try
                    {
                        BrightnessControllerGammaRamp.SetBrightness((int)newval);
                    }
                    catch
                    {

                    }
                }

                return 0;
            }            
        }

        public static int SetTask(byte targetBrightness)
        {
            try
            {
                ManagementScope scope = new ManagementScope("root\\WMI");
                SelectQuery query = new SelectQuery("WmiMonitorBrightnessMethods");
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
                {
                    using (ManagementObjectCollection objectCollection = searcher.Get())
                    {
                        foreach (ManagementObject mObj in objectCollection)
                        {
                            mObj.InvokeMethod("WmiSetBrightness",
                                new Object[] { UInt32.MaxValue, targetBrightness });
                            break;
                        }
                    }
                }

                return BrightnessControllerGammaRamp.SetBrightness(targetBrightness);

                return 0;
            }
            catch
            {
                try
                {
                    return BrightnessControllerGammaRamp.SetBrightness(targetBrightness);
                }
                catch
                {

                    return -1;
                }
            }
        }
    }
}
