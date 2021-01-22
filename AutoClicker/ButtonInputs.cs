using System;
using System.Windows.Forms;

namespace AutoClicker
{
    public partial class ButtonInputs : UserControl
    {
        public event EventHandler UseButtonChanged;
        public event EventHandler HoldButtonChanged;
        public event EventHandler DelayChanged;

        public bool Use { get => cbButtonEnable.Checked; set => cbButtonEnable.Checked = value; }
        public bool Hold { get => cbHold.Checked; set => cbHold.Checked = value; }
        public int Delay { get => (int)numDelay.Value; set => numDelay.Value = value; }

        private string _buttonName;
        public string ButtonName { get => _buttonName; set { _buttonName = value; cbButtonEnable.Text = value; } }
        public uint ButtonDownCode { get; set; }
        public uint ButtonUpCode { get; set; }

        public bool Needed => cbButtonEnable.Checked;

        public ButtonInputs()
        {
            InitializeComponent();
            numDelay.Maximum = int.MaxValue;
            numDelay.Value = 200;
        }

        internal Clicker StartClicking(IntPtr minecraftHandle)
        {
            var delay = cbHold.Checked ? 0 : (int)numDelay.Value;
            var clicker = new Clicker(ButtonDownCode, ButtonUpCode, minecraftHandle);

            clicker.Start(delay);

            return clicker;
        }

        private void numDelay_ValueChanged(object sender, EventArgs e)
        {
            DelayChanged?.Invoke(this, EventArgs.Empty);
        }

        private void cbButtonEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (cbButtonEnable.Checked)
            {
                cbHold.Enabled = true;
                cbHold_CheckedChanged(cbHold, EventArgs.Empty);
            }
            else
            {
                cbHold.Enabled = false;
                numDelay.Enabled = false;
                lblDelay.Enabled = false;
            }
            UseButtonChanged?.Invoke(this, EventArgs.Empty);
        }

        private void cbHold_CheckedChanged(object sender, EventArgs e)
        {
            HoldButtonChanged?.Invoke(this, EventArgs.Empty);
            numDelay.Enabled = !cbHold.Checked;
            lblDelay.Enabled = !cbHold.Checked;
        }
    }
}
