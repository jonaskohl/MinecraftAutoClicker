using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClicker
{
    public static class MinecraftDirectoryDetector
    {
        public static bool IsMinecraftDirectory(string path)
        {
            return
                Directory.Exists(Path.Combine(path, "saves")) &&
                Directory.Exists(Path.Combine(path, "screenshots")) &&
                Directory.Exists(Path.Combine(path, "resourcepacks")) &&
                Directory.Exists(Path.Combine(path, "logs")) &&
                Directory.Exists(Path.Combine(path, "crash-reports")) &&
                File.Exists(Path.Combine(path, "options.txt"))
            ;
        }

        public static string[] SearchForMinecraftDirectories()
        {
            return Directory.GetDirectories(Environment.ExpandEnvironmentVariables("%appdata%")).Where(x => IsMinecraftDirectory(x)).ToArray();
        }
    }
}
