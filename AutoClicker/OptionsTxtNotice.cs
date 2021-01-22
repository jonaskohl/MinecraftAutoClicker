using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoClicker
{
    public partial class OptionsTxtNotice : Form
    {
        string[] dirs;
        bool invokeSelectedIndexChanged = false;

        public OptionsTxtNotice()
        {
            InitializeComponent();

            Shown += OptionsTxtNotice_Shown;
        }

        private void OptionsTxtNotice_Shown(object sender, EventArgs e)
        {
            Shown -= OptionsTxtNotice_Shown;
            dirs = MinecraftDirectoryDetector.SearchForMinecraftDirectories();
            comboBox1.DataSource = dirs;
            comboBox1.SelectedIndex = Math.Max(0, Array.IndexOf(dirs, SettingsManager.Get("lastMCPath")));
            invokeSelectedIndexChanged = true;
            comboBox1_SelectedIndexChanged(comboBox1, EventArgs.Empty);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!invokeSelectedIndexChanged)
                return;
            var dir = dirs[comboBox1.SelectedIndex];
            var val = !OptionsTxtChecker.CheckPauseOnLostFocusReady(dir);
            button1.Visible = val;
            label2.Visible = val;
            SettingsManager.Set("lastMCPath", dir);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OptionsTxtChecker.SetPauseOnLostFocus(dirs[comboBox1.SelectedIndex]);
            var val = !OptionsTxtChecker.CheckPauseOnLostFocusReady(dirs[comboBox1.SelectedIndex]);
            button1.Visible = val;
            label2.Visible = val;
            if (!val)
                button2.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
