namespace AutoClicker
{
    partial class ButtonInputs
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbButtonEnable = new System.Windows.Forms.CheckBox();
            this.cbHold = new System.Windows.Forms.CheckBox();
            this.lblDelay = new System.Windows.Forms.Label();
            this.numDelay = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // cbButtonEnable
            // 
            this.cbButtonEnable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbButtonEnable.AutoSize = true;
            this.cbButtonEnable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbButtonEnable.Location = new System.Drawing.Point(14, 12);
            this.cbButtonEnable.Name = "cbButtonEnable";
            this.cbButtonEnable.Size = new System.Drawing.Size(101, 20);
            this.cbButtonEnable.TabIndex = 1;
            this.cbButtonEnable.Text = "Button name";
            this.cbButtonEnable.UseVisualStyleBackColor = true;
            this.cbButtonEnable.CheckedChanged += new System.EventHandler(this.cbButtonEnable_CheckedChanged);
            // 
            // cbHold
            // 
            this.cbHold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbHold.AutoSize = true;
            this.cbHold.Enabled = false;
            this.cbHold.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbHold.Location = new System.Drawing.Point(14, 37);
            this.cbHold.Name = "cbHold";
            this.cbHold.Size = new System.Drawing.Size(97, 20);
            this.cbHold.TabIndex = 2;
            this.cbHold.Text = "Hold button";
            this.cbHold.UseVisualStyleBackColor = true;
            this.cbHold.CheckedChanged += new System.EventHandler(this.cbHold_CheckedChanged);
            // 
            // lblDelay
            // 
            this.lblDelay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDelay.AutoSize = true;
            this.lblDelay.Location = new System.Drawing.Point(11, 59);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(66, 15);
            this.lblDelay.TabIndex = 3;
            this.lblDelay.Text = "Delay (ms):";
            // 
            // numDelay
            // 
            this.numDelay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numDelay.Enabled = false;
            this.numDelay.Location = new System.Drawing.Point(111, 57);
            this.numDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDelay.Name = "numDelay";
            this.numDelay.Size = new System.Drawing.Size(159, 23);
            this.numDelay.TabIndex = 4;
            this.numDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDelay.ValueChanged += new System.EventHandler(this.numDelay_ValueChanged);
            // 
            // ButtonInputs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numDelay);
            this.Controls.Add(this.lblDelay);
            this.Controls.Add(this.cbHold);
            this.Controls.Add(this.cbButtonEnable);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ButtonInputs";
            this.Size = new System.Drawing.Size(280, 93);
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox cbButtonEnable;
        private System.Windows.Forms.CheckBox cbHold;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.NumericUpDown numDelay;
    }
}
