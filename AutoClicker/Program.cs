using System;
using System.IO;
using System.Windows.Forms;

namespace AutoClicker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (
                File.Exists(SettingsManager.SettingsFilePathOld) &&
                !File.Exists(SettingsManager.SettingsFilePath)
            )
                File.Move(SettingsManager.SettingsFilePathOld, SettingsManager.SettingsFilePath);

            SettingsManager.Load();

            var o = new OptionsTxtNotice();
            o.ShowDialog();

            Application.Run(new Main());

            SettingsManager.Save();
        }
    }
}
