using System;
using System.Collections.Generic;

using System.Text;

namespace BrightnessWheel
{
    public class ArgsManager
    {
        public static bool IsHidden
        {
            get
            {
                for (int k = 0; k < Module.args.Length; k++)
                {
                    if (Module.args[k].Trim().ToLower() == "/hide")
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public static bool IsNovisible
        {
            get
            {
                for (int k = 0; k < Module.args.Length; k++)
                {
                    if (Module.args[k].Trim().ToLower() == "/novisible")
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public static bool IsMinimized
        {
            get
            {
                for (int k = 0; k < Module.args.Length; k++)
                {
                    if (Module.args[k].Trim().ToLower() == "/minimized")
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public static bool IsRestart
        {
            get
            {
                for (int k = 0; k < Module.args.Length; k++)
                {
                    if (Module.args[k].Trim().ToLower() == "/restart")
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
