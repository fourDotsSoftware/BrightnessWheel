using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
namespace BrightnessWheelGet
{
    class Program
    {
        static int Main(string[] args)
        {
            int option = int.Parse(args[0]);

            if (option == 0)
            {
                return GetTask();
            }
            else
            {
                //PhysicalMonitorBrightnessController pr = new PhysicalMonitorBrightnessController();
                //return pr.Get();

                try
                {
                    BrightnessController bcon = new BrightnessController();

                    return (int)bcon._currentValue;
                }
                catch
                {
                    return BrightnessControllerGammaRamp.GetBrightness();
                }
            }
        }

        public static int GetTask()
        {
            try
            {
                ManagementScope scope;
                SelectQuery query;

                scope = new ManagementScope("root\\WMI");
                query = new SelectQuery("SELECT * FROM WmiMonitorBrightness");

                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
                {
                    using (ManagementObjectCollection objectCollection = searcher.Get())
                    {
                        foreach (ManagementObject mObj in objectCollection)
                        {
                            Console.WriteLine(mObj.ClassPath);
                            foreach (var item in mObj.Properties)
                            {
                                Console.WriteLine(item.Name + " " + item.Value.ToString());
                                if (item.Name == "CurrentBrightness")
                                {
                                    return int.Parse(item.Value.ToString());
                                }
                                //Do something with CurrentBrightness
                            }
                        }
                    }
                }

                return BrightnessControllerGammaRamp.GetBrightness();

                return -1;
            }
            catch {

                return BrightnessControllerGammaRamp.GetBrightness();

                return -1;
            }

        }
    }
}
