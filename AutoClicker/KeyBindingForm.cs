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
    public partial class KeyBindingForm : Form
    {
        public bool UseHook { get; set; }
        public ModifierKeys HModifierKeys { get; set; }
        public Keys HKey { get; set; }

        public KeyBindingForm()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                HModifierKeys = AutoClicker.ModifierKeys.None;
                HKey = Keys.None;
                UseHook = false;
            }
            else
            {
                UseHook = true;
                var m = AutoClicker.ModifierKeys.None;
                if (e.Modifiers.HasFlag(Keys.Control)) m |= AutoClicker.ModifierKeys.Control;
                if (e.Modifiers.HasFlag(Keys.Shift)) m |= AutoClicker.ModifierKeys.Shift;
                if (e.Modifiers.HasFlag(Keys.Alt)) m |= AutoClicker.ModifierKeys.Alt;

                HModifierKeys = m;
                HKey = e.KeyCode;
            }
            Display();

            e.SuppressKeyPress = true;
            e.Handled = true;
        }

        public void Display()
        {
            if (!UseHook)
            {
                textBox1.Text = "(None)";
                return;
            }

            var s = string.Join("+", HModifierKeys.ToString().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Where(x => x != "None").ToArray());
            if (s.Length > 0)
                textBox1.Text = s + "+" + HKey.ToString();
            else
                textBox1.Text = HKey.ToString();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            button1.Focus();
        }
    }
}
