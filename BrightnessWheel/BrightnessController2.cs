using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace BrightnessWheel
{
    public class BrightnessController2
    {                
        public  int GetTask()
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

            return 0;
        }

        public  void SetTask(byte targetBrightness)
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
        }

        private static int UseExternalMonitors = -1;

        public static int Get()
        {
            if (UseExternalMonitors == -1 || UseExternalMonitors == 0)
            {
                ProcessStartInfo pinfo = new ProcessStartInfo();
                pinfo.FileName = System.IO.Path.Combine(Application.StartupPath, "BrightnessWheelGet.exe");
                pinfo.Arguments = "0";
                pinfo.UseShellExecute = true;
                pinfo.WindowStyle = ProcessWindowStyle.Hidden;

                Process pr = new Process();
                pr.StartInfo = pinfo;

                pr.Start();
                pr.WaitForExit();

                if (pr.ExitCode==-1)
                {
                    UseExternalMonitors = 1;

                    return Get();
                }
                else
                {
                    UseExternalMonitors = 0;
                }

                return pr.ExitCode;
            }
            else
            {
                ProcessStartInfo pinfo = new ProcessStartInfo();
                pinfo.FileName = System.IO.Path.Combine(Application.StartupPath, "BrightnessWheelGet.exe");
                pinfo.Arguments = "1";
                pinfo.UseShellExecute = true;
                pinfo.WindowStyle = ProcessWindowStyle.Hidden;

                Process pr = new Process();
                pr.StartInfo = pinfo;

                pr.Start();
                pr.WaitForExit();                

                return pr.ExitCode;
            }
        }

        public static int Set(byte brightness)
        {
            if (UseExternalMonitors == -1 || UseExternalMonitors == 0)
            {
                ProcessStartInfo pinfo = new ProcessStartInfo();
                pinfo.FileName = System.IO.Path.Combine(Application.StartupPath, "BrightnessWheelSet.exe");
                pinfo.Arguments = "0 "+brightness.ToString();
                pinfo.UseShellExecute = true;
                pinfo.WindowStyle = ProcessWindowStyle.Hidden;

                Process pr = new Process();
                pr.StartInfo = pinfo;

                pr.Start();
                pr.WaitForExit();

                return pr.ExitCode;
            }
            else
            {
                ProcessStartInfo pinfo = new ProcessStartInfo();
                pinfo.FileName = System.IO.Path.Combine(Application.StartupPath, "BrightnessWheelSet.exe");
                pinfo.Arguments = "1 "+brightness.ToString();
                pinfo.UseShellExecute = true;
                pinfo.WindowStyle = ProcessWindowStyle.Hidden;

                Process pr = new Process();
                pr.StartInfo = pinfo;

                pr.Start();
                pr.WaitForExit();

                return pr.ExitCode;
            }
        }

    }
}
