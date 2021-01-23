using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace AutoClicker
{
    public partial class Main : Form
    {
        private KeyboardHook Hook;
        private ModifierKeys HModifierKeys;
        private Keys HKey;
        private bool HOpen;
        private bool isRunning;

        private readonly Dictionary<Process, List<Clicker>> instanceClickers = new Dictionary<Process, List<Clicker>>();
        private static readonly List<string> WindowTitles = new List<string>
        {
            "Minecraft",
            "RLCraft"
        };

        DateTime startTime;

        public Main()
        {
            InitializeComponent();
            Icon = Properties.Resources.mcautoclicker_normal;

            Shown += Main_Shown;

            Menu = mainMenu1;

            if (!SettingsManager.Get<bool>("alwaysUseDefaultPos") && SettingsManager.Get<bool>("useLastPos"))
            {
                StartPosition = FormStartPosition.Manual;
                Location = new System.Drawing.Point(
                    SettingsManager.Get<int>("lastPosX"),
                    SettingsManager.Get<int>("lastPosY")
                );
            }

            HModifierKeys = (ModifierKeys)SettingsManager.Get<int>("hotkeyModifiers");
            HKey = (Keys)SettingsManager.Get<int>("hotkeyMain");

            if (HModifierKeys != AutoClicker.ModifierKeys.None && HKey != Keys.None)
            {
                RegisterHook();
            }
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            Shown -= Main_Shown;
            biLeftMouse.Use = (bool)SettingsManager.Get("useLeft");
            biLeftMouse.Hold = (bool)SettingsManager.Get("holdLeft");
            biLeftMouse.Delay = (int)SettingsManager.Get("delayLeft");
            biRightMouse.Use = (bool)SettingsManager.Get("useRight");
            biRightMouse.Hold = (bool)SettingsManager.Get("holdRight");
            biRightMouse.Delay = (int)SettingsManager.Get("delayRight");
        }

        private void Btn_action_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void Start()
        {
            try
            {
                EnableElements(false);
                var mcProcesses = Process.GetProcesses().Where(b => b.ProcessName.StartsWith("java") && WindowTitles.Any(title => b.MainWindowTitle.Contains(title))).ToList();
                var mainHandle = Handle;

                if (!mcProcesses.Any())
                {
                    // if we first don't find any windows matching an expected name, give the user the ability to override
                    var notRunning = new NotRunning();
                    if (notRunning.ShowDialog() != DialogResult.OK)
                    {
                        EnableElements(true);
                        return;
                    }

                    if (!string.IsNullOrEmpty(notRunning.ProcessTitle))
                        mcProcesses = Process.GetProcesses().Where(b => b.MainWindowTitle == notRunning.ProcessTitle).ToList();
                }

                if (!mcProcesses.Any())
                {
                    MessageBox.Show(@"Unable to find Minecraft process!", @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EnableElements(true);
                    return;
                }

                btn_stop.Focus();

                if (mcProcesses.Count > 1)
                {
                    using (var instancesForm = new MultipleInstances(mcProcesses))
                    {
                        if (instancesForm.ShowDialog() != DialogResult.OK)
                        {
                            EnableElements(true);
                            return;
                        }

                        mcProcesses = instancesForm.SelectedInstances.Select(Process.GetProcessById).ToList();
                    }
                }

                //lblStartTime.Text = DateTime.Now.ToString("MMMM dd HH:mm tt");
                startTime = DateTime.Now;
                lblStarted.Visible = true;
                lblStartTime.Visible = true;
                updateTimeTimer.Start();
                updateTimeTimer_Tick(updateTimeTimer, EventArgs.Empty);
                isRunning = true;

                foreach (var mcProcess in mcProcesses)
                {
                    SetControlPropertyThreadSafe(btn_start, "Enabled", false);
                    SetControlPropertyThreadSafe(btn_stop, "Enabled", true);

                    var minecraftHandle = mcProcess.MainWindowHandle;
                    FocusToggle(minecraftHandle);

                    if (SettingsManager.Get<bool>("delayBeforeStart"))
                        Thread.Sleep(SettingsManager.Get<int>("delayLength"));

                    FocusToggle(mainHandle);
                    //Thread.Sleep(500);

                    iconAnimateTimer.Start();
                    if (SettingsManager.Get<bool>("useTaskbarIndicator"))
                        TaskbarProgress.SetState(Handle, TaskbarProgress.TaskbarStates.Indeterminate);

                    if (biRightMouse.Needed)
                    {
                        var clicker = biRightMouse.StartClicking(minecraftHandle);
                        AddToInstanceClickers(mcProcess, clicker);
                    }

                    //Thread.Sleep(100);

                    if (biLeftMouse.Needed)
                    {
                        var clicker = biLeftMouse.StartClicking(minecraftHandle);
                        AddToInstanceClickers(mcProcess, clicker);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Stop();
            }
        }

        private void AddToInstanceClickers(Process mcProcess, Clicker clicker)
        {
            if (instanceClickers.ContainsKey(mcProcess))
                instanceClickers[mcProcess].Add(clicker);
            else
                instanceClickers.Add(mcProcess, new List<Clicker> { clicker });
        }

        private void Btn_stop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void Stop()
        {
            isRunning = false;
            btn_stop.Enabled = false;
            btn_stop.Hide();
            iconAnimateTimer.Stop();
            TaskbarProgress.SetState(Handle, TaskbarProgress.TaskbarStates.NoProgress);
            Icon = Properties.Resources.mcautoclicker_normal;

            if (SettingsManager.Get<bool>("focusTargetWhenStopped"))
            {
                try
                {
                    FocusToggle(instanceClickers.Keys.ElementAt(0).MainWindowHandle);
                }
                catch { }
            }

            foreach (var clickers in instanceClickers.Values)
            {
                foreach (var clicker in clickers)
                {
                    clicker?.Dispose();
                }
            }

            instanceClickers.Clear();

            lblStarted.Visible = false;
            lblStartTime.Visible = false;
            updateTimeTimer.Stop();

            //btn_start.Text = "START";
            EnableElements(true);

            btn_start.Focus();
        }

        private void EnableElements(bool enable)
        {
            btn_start.Enabled = enable;
            biLeftMouse.Enabled = enable;
            biRightMouse.Enabled = enable;
            btn_stop.Enabled = !enable;
            btn_stop.Visible = !enable;
        }

        private static void FocusToggle(IntPtr hwnd)
        {
            Thread.Sleep(200);
            Win32Api.SetForegroundWindow(hwnd);
        }

        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);
        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
                control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe), control, propertyName, propertyValue);
            else
                control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new[] { propertyValue });
        }//end SetControlPropertyThreadSafe

        private void biLeftMouse_UseButtonChanged(object sender, EventArgs e)
        {
            SettingsManager.Set("useLeft", biLeftMouse.Use);
        }

        private void biLeftMouse_HoldButtonChanged(object sender, EventArgs e)
        {
            SettingsManager.Set("holdLeft", biLeftMouse.Hold);
        }

        private void biLeftMouse_DelayChanged(object sender, EventArgs e)
        {
            SettingsManager.Set("delayLeft", biLeftMouse.Delay);
        }

        private void biRightMouse_UseButtonChanged(object sender, EventArgs e)
        {
            SettingsManager.Set("useRight", biRightMouse.Use);
        }

        private void biRightMouse_HoldButtonChanged(object sender, EventArgs e)
        {
            SettingsManager.Set("holdRight", biRightMouse.Hold);
        }

        private void biRightMouse_DelayChanged(object sender, EventArgs e)
        {
            SettingsManager.Set("delayRight", biRightMouse.Delay);
        }

        int ico = 0;
        private void iconAnimateTimer_Tick(object sender, EventArgs e)
        {
            if (ico == 0)
                Icon = Properties.Resources.mcautoclicker_active0;
            else if (ico == 1)
                Icon = Properties.Resources.mcautoclicker_active1;
            ico = (ico + 1) % 2;
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            using (var f = new AboutBox1())
                f.ShowDialog(this);
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            Process.Start(Environment.ExpandEnvironmentVariables(@"%systemroot%\system32\notepad.exe"), EncodeParameterArgument(SettingsManager.SettingsFilePath));
        }

        public static string EncodeParameterArgument(string original)
        {
            if (string.IsNullOrEmpty(original))
                return original;
            string value = Regex.Replace(original, @"(\\*)" + "\"", @"$1\$0");
            value = Regex.Replace(value, @"^(.*\s.*?)(\\*)$", "\"$1$2$2\"");
            return value;
        }

        public static string EncodeParameterArgumentMultiLine(string original)
        {
            if (string.IsNullOrEmpty(original))
                return original;
            string value = Regex.Replace(original, @"(\\*)" + "\"", @"$1\$0");
            value = Regex.Replace(value, @"^(.*\s.*?)(\\*)$", "\"$1$2$2\"", RegexOptions.Singleline);

            return value;
        }

        private void updateTimeTimer_Tick(object sender, EventArgs e)
        {
            var delta = (DateTime.Now - startTime);
            delta.Add(TimeSpan.FromMilliseconds(-delta.Milliseconds));
            lblStartTime.Text = delta.ToString(@"h\:mm\:ss");
        }

        private void Main_Move(object sender, EventArgs e)
        {
            SettingsManager.Set("lastPosX", Location.X);
            SettingsManager.Set("lastPosY", Location.Y);
            SettingsManager.Set("useLastPos", true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void UnregisterHook()
        {
            if (Hook != null)
            {
                Hook.KeyPressed -= Hook_KeyPressed;
                Hook.Dispose();

                Hook = null;
            }
        }

        private void RegisterHook()
        {
            UnregisterHook();

            Hook = new KeyboardHook();
            Hook.RegisterHotKey(HModifierKeys, HKey);
            Hook.KeyPressed += Hook_KeyPressed;
        }

        private void Hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (HOpen) return;
            if (isRunning)
                Stop();
            else
                Start();
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            using (var f = new KeyBindingForm())
            {
                f.UseHook = Hook != null;
                f.HModifierKeys = HModifierKeys;
                f.HKey = HKey;
                f.Display();
                HOpen = true;
                var r = f.ShowDialog(this);
                HOpen = false;
                if (r == DialogResult.OK)
                {
                    if (f.UseHook)
                    {
                        HModifierKeys = f.HModifierKeys;
                        HKey = f.HKey;

                        RegisterHook();

                        SettingsManager.Set("hotkeyModifiers", (int)HModifierKeys);
                        SettingsManager.Set("hotkeyMain", (int)HKey);
                    }
                    else
                    {
                        UnregisterHook();

                        SettingsManager.Set("hotkeyModifiers", 0);
                        SettingsManager.Set("hotkeyMain", 0);
                    }
                }
            }
        }
    }
}
