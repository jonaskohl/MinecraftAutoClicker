namespace AutoClicker
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_start = new System.Windows.Forms.Button();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.btn_stop = new System.Windows.Forms.Button();
            this.lblStarted = new System.Windows.Forms.Label();
            this.iconAnimateTimer = new System.Windows.Forms.Timer(this.components);
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.updateTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.biRightMouse = new AutoClicker.ButtonInputs();
            this.biLeftMouse = new AutoClicker.ButtonInputs();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_start.Location = new System.Drawing.Point(12, 108);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(580, 30);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "&Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.Btn_action_Click);
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(83, 141);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(31, 15);
            this.lblStartTime.TabIndex = 2;
            this.lblStartTime.Text = "time";
            this.lblStartTime.Visible = false;
            // 
            // btn_stop
            // 
            this.btn_stop.Enabled = false;
            this.btn_stop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_stop.Location = new System.Drawing.Point(12, 108);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(580, 30);
            this.btn_stop.TabIndex = 3;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Visible = false;
            this.btn_stop.Click += new System.EventHandler(this.Btn_stop_Click);
            // 
            // lblStarted
            // 
            this.lblStarted.AutoSize = true;
            this.lblStarted.Location = new System.Drawing.Point(12, 141);
            this.lblStarted.Name = "lblStarted";
            this.lblStarted.Size = new System.Drawing.Size(73, 15);
            this.lblStarted.TabIndex = 6;
            this.lblStarted.Text = "Running for:";
            this.lblStarted.Visible = false;
            // 
            // iconAnimateTimer
            // 
            this.iconAnimateTimer.Interval = 250;
            this.iconAnimateTimer.Tick += new System.EventHandler(this.iconAnimateTimer_Tick);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem3,
            this.menuItem1});
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "&Settings...";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 2;
            this.menuItem1.Text = "&About...";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // updateTimeTimer
            // 
            this.updateTimeTimer.Interval = 500;
            this.updateTimeTimer.Tick += new System.EventHandler(this.updateTimeTimer_Tick);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "&Hotkey...";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // biRightMouse
            // 
            this.biRightMouse.ButtonDownCode = ((uint)(516u));
            this.biRightMouse.ButtonName = "Right mouse button";
            this.biRightMouse.ButtonUpCode = ((uint)(517u));
            this.biRightMouse.Delay = 200;
            this.biRightMouse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.biRightMouse.Hold = false;
            this.biRightMouse.Location = new System.Drawing.Point(301, 21);
            this.biRightMouse.Name = "biRightMouse";
            this.biRightMouse.Size = new System.Drawing.Size(280, 81);
            this.biRightMouse.TabIndex = 5;
            this.biRightMouse.Use = false;
            this.biRightMouse.UseButtonChanged += new System.EventHandler(this.biRightMouse_UseButtonChanged);
            this.biRightMouse.HoldButtonChanged += new System.EventHandler(this.biRightMouse_HoldButtonChanged);
            this.biRightMouse.DelayChanged += new System.EventHandler(this.biRightMouse_DelayChanged);
            // 
            // biLeftMouse
            // 
            this.biLeftMouse.ButtonDownCode = ((uint)(513u));
            this.biLeftMouse.ButtonName = "Left mouse button";
            this.biLeftMouse.ButtonUpCode = ((uint)(514u));
            this.biLeftMouse.Delay = 200;
            this.biLeftMouse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.biLeftMouse.Hold = false;
            this.biLeftMouse.Location = new System.Drawing.Point(14, 21);
            this.biLeftMouse.Name = "biLeftMouse";
            this.biLeftMouse.Size = new System.Drawing.Size(280, 81);
            this.biLeftMouse.TabIndex = 4;
            this.biLeftMouse.Use = false;
            this.biLeftMouse.UseButtonChanged += new System.EventHandler(this.biLeftMouse_UseButtonChanged);
            this.biLeftMouse.HoldButtonChanged += new System.EventHandler(this.biLeftMouse_HoldButtonChanged);
            this.biLeftMouse.DelayChanged += new System.EventHandler(this.biLeftMouse_DelayChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 166);
            this.Controls.Add(this.lblStarted);
            this.Controls.Add(this.biRightMouse);
            this.Controls.Add(this.biLeftMouse);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.btn_start);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minecraft Auto-Clicker";
            this.Move += new System.EventHandler(this.Main_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Button btn_stop;
        private ButtonInputs biLeftMouse;
        private ButtonInputs biRightMouse;
        private System.Windows.Forms.Label lblStarted;
        private System.Windows.Forms.Timer iconAnimateTimer;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.Timer updateTimeTimer;
        private System.Windows.Forms.MenuItem menuItem3;
    }
}

