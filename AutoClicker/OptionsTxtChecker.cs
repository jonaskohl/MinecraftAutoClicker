using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClicker
{
    public static class OptionsTxtChecker
    {
        public static bool CheckPauseOnLostFocusReady(string path)
        {
            var contents = File.ReadAllText(Path.Combine(path, "options.txt"));
            if (contents.Contains("pauseOnLostFocus:false"))
                return true;
            return false;
        }

        public static void SetPauseOnLostFocus(string path)
        {
            var contents = File.ReadAllText(Path.Combine(path, "options.txt"));
            contents = contents.Replace("pauseOnLostFocus:true", "pauseOnLostFocus:false");
            File.WriteAllText(Path.Combine(path, "options.txt"), contents);
        }
    }
}
