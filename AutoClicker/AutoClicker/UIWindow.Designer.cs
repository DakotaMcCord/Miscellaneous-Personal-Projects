
namespace AutoClicker {
    partial class UIWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.NUD_DelayHours = new System.Windows.Forms.NumericUpDown();
            this.NUD_DelayMinute = new System.Windows.Forms.NumericUpDown();
            this.NUD_DelaySeconds = new System.Windows.Forms.NumericUpDown();
            this.NUD_DelayMSeconds = new System.Windows.Forms.NumericUpDown();
            this.BTN_StartStop = new System.Windows.Forms.Button();
            this.BTN_HotkeyEdit = new System.Windows.Forms.Button();
            this.SLDR_ClickType = new System.Windows.Forms.TrackBar();
            this.LBL_LClick = new System.Windows.Forms.Label();
            this.LBL_LHold = new System.Windows.Forms.Label();
            this.LBL_RClick = new System.Windows.Forms.Label();
            this.LBL_RHold = new System.Windows.Forms.Label();
            this.LBL_MClick = new System.Windows.Forms.Label();
            this.LBL_MHold = new System.Windows.Forms.Label();
            this.LBL_Hours = new System.Windows.Forms.Label();
            this.LBL_Minutes = new System.Windows.Forms.Label();
            this.LBL_Seconds = new System.Windows.Forms.Label();
            this.LBL_Milliseconds = new System.Windows.Forms.Label();
            this.GB_ClickSelect = new System.Windows.Forms.GroupBox();
            this.GB_CInterval = new System.Windows.Forms.GroupBox();
            this.GB_ReapeatType = new System.Windows.Forms.GroupBox();
            this.LBL_RTimes = new System.Windows.Forms.Label();
            this.LBL_RInfinite = new System.Windows.Forms.Label();
            this.SLDR_RepeatType = new System.Windows.Forms.TrackBar();
            this.NUD_TimesAmount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DelayHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DelayMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DelaySeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DelayMSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SLDR_ClickType)).BeginInit();
            this.GB_ClickSelect.SuspendLayout();
            this.GB_CInterval.SuspendLayout();
            this.GB_ReapeatType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SLDR_RepeatType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_TimesAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // NUD_DelayHours
            // 
            this.NUD_DelayHours.Location = new System.Drawing.Point(7, 44);
            this.NUD_DelayHours.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NUD_DelayHours.Name = "NUD_DelayHours";
            this.NUD_DelayHours.Size = new System.Drawing.Size(67, 20);
            this.NUD_DelayHours.TabIndex = 0;
            this.NUD_DelayHours.TabStop = false;
            // 
            // NUD_DelayMinute
            // 
            this.NUD_DelayMinute.Location = new System.Drawing.Point(80, 44);
            this.NUD_DelayMinute.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.NUD_DelayMinute.Name = "NUD_DelayMinute";
            this.NUD_DelayMinute.Size = new System.Drawing.Size(67, 20);
            this.NUD_DelayMinute.TabIndex = 1;
            this.NUD_DelayMinute.TabStop = false;
            // 
            // NUD_DelaySeconds
            // 
            this.NUD_DelaySeconds.Location = new System.Drawing.Point(153, 44);
            this.NUD_DelaySeconds.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.NUD_DelaySeconds.Name = "NUD_DelaySeconds";
            this.NUD_DelaySeconds.Size = new System.Drawing.Size(67, 20);
            this.NUD_DelaySeconds.TabIndex = 2;
            this.NUD_DelaySeconds.TabStop = false;
            this.NUD_DelaySeconds.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // NUD_DelayMSeconds
            // 
            this.NUD_DelayMSeconds.Location = new System.Drawing.Point(226, 44);
            this.NUD_DelayMSeconds.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUD_DelayMSeconds.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.NUD_DelayMSeconds.Name = "NUD_DelayMSeconds";
            this.NUD_DelayMSeconds.Size = new System.Drawing.Size(67, 20);
            this.NUD_DelayMSeconds.TabIndex = 3;
            this.NUD_DelayMSeconds.TabStop = false;
            this.NUD_DelayMSeconds.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // BTN_StartStop
            // 
            this.BTN_StartStop.Location = new System.Drawing.Point(6, 212);
            this.BTN_StartStop.Name = "BTN_StartStop";
            this.BTN_StartStop.Size = new System.Drawing.Size(140, 23);
            this.BTN_StartStop.TabIndex = 5;
            this.BTN_StartStop.TabStop = false;
            this.BTN_StartStop.Text = "Start/Stop: (Inactive)";
            this.BTN_StartStop.UseVisualStyleBackColor = true;
            this.BTN_StartStop.Click += new System.EventHandler(this.BTN_StartStop_Click);
            // 
            // BTN_HotkeyEdit
            // 
            this.BTN_HotkeyEdit.Location = new System.Drawing.Point(171, 212);
            this.BTN_HotkeyEdit.Name = "BTN_HotkeyEdit";
            this.BTN_HotkeyEdit.Size = new System.Drawing.Size(140, 23);
            this.BTN_HotkeyEdit.TabIndex = 6;
            this.BTN_HotkeyEdit.TabStop = false;
            this.BTN_HotkeyEdit.Text = "Edit Hotkeys";
            this.BTN_HotkeyEdit.UseVisualStyleBackColor = true;
            this.BTN_HotkeyEdit.Click += new System.EventHandler(this.BTN_HotkeyEdit_Click);
            // 
            // SLDR_ClickType
            // 
            this.SLDR_ClickType.LargeChange = 1;
            this.SLDR_ClickType.Location = new System.Drawing.Point(20, 44);
            this.SLDR_ClickType.Maximum = 5;
            this.SLDR_ClickType.Name = "SLDR_ClickType";
            this.SLDR_ClickType.Size = new System.Drawing.Size(356, 45);
            this.SLDR_ClickType.TabIndex = 7;
            this.SLDR_ClickType.TabStop = false;
            this.SLDR_ClickType.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.SLDR_ClickType.Scroll += new System.EventHandler(this.SLDR_ClickType_Scroll);
            // 
            // LBL_LClick
            // 
            this.LBL_LClick.AutoSize = true;
            this.LBL_LClick.Location = new System.Drawing.Point(15, 28);
            this.LBL_LClick.Name = "LBL_LClick";
            this.LBL_LClick.Size = new System.Drawing.Size(51, 13);
            this.LBL_LClick.TabIndex = 8;
            this.LBL_LClick.Text = "Left Click";
            this.LBL_LClick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_LHold
            // 
            this.LBL_LHold.AutoSize = true;
            this.LBL_LHold.Location = new System.Drawing.Point(82, 28);
            this.LBL_LHold.Name = "LBL_LHold";
            this.LBL_LHold.Size = new System.Drawing.Size(50, 13);
            this.LBL_LHold.TabIndex = 9;
            this.LBL_LHold.Text = "Left Hold";
            this.LBL_LHold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_RClick
            // 
            this.LBL_RClick.AutoSize = true;
            this.LBL_RClick.Location = new System.Drawing.Point(147, 28);
            this.LBL_RClick.Name = "LBL_RClick";
            this.LBL_RClick.Size = new System.Drawing.Size(58, 13);
            this.LBL_RClick.TabIndex = 10;
            this.LBL_RClick.Text = "Right Click";
            this.LBL_RClick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_RHold
            // 
            this.LBL_RHold.AutoSize = true;
            this.LBL_RHold.Location = new System.Drawing.Point(211, 28);
            this.LBL_RHold.Name = "LBL_RHold";
            this.LBL_RHold.Size = new System.Drawing.Size(57, 13);
            this.LBL_RHold.TabIndex = 11;
            this.LBL_RHold.Text = "Right Hold";
            this.LBL_RHold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_MClick
            // 
            this.LBL_MClick.AutoSize = true;
            this.LBL_MClick.Location = new System.Drawing.Point(274, 28);
            this.LBL_MClick.Name = "LBL_MClick";
            this.LBL_MClick.Size = new System.Drawing.Size(64, 13);
            this.LBL_MClick.TabIndex = 12;
            this.LBL_MClick.Text = "Middle Click";
            this.LBL_MClick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_MHold
            // 
            this.LBL_MHold.AutoSize = true;
            this.LBL_MHold.Location = new System.Drawing.Point(344, 28);
            this.LBL_MHold.Name = "LBL_MHold";
            this.LBL_MHold.Size = new System.Drawing.Size(63, 13);
            this.LBL_MHold.TabIndex = 13;
            this.LBL_MHold.Text = "Middle Hold";
            this.LBL_MHold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_Hours
            // 
            this.LBL_Hours.AutoSize = true;
            this.LBL_Hours.Location = new System.Drawing.Point(17, 28);
            this.LBL_Hours.Name = "LBL_Hours";
            this.LBL_Hours.Size = new System.Drawing.Size(35, 13);
            this.LBL_Hours.TabIndex = 14;
            this.LBL_Hours.Text = "Hours";
            this.LBL_Hours.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_Minutes
            // 
            this.LBL_Minutes.AutoSize = true;
            this.LBL_Minutes.Location = new System.Drawing.Point(91, 28);
            this.LBL_Minutes.Name = "LBL_Minutes";
            this.LBL_Minutes.Size = new System.Drawing.Size(44, 13);
            this.LBL_Minutes.TabIndex = 15;
            this.LBL_Minutes.Text = "Minutes";
            this.LBL_Minutes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_Seconds
            // 
            this.LBL_Seconds.AutoSize = true;
            this.LBL_Seconds.Location = new System.Drawing.Point(159, 28);
            this.LBL_Seconds.Name = "LBL_Seconds";
            this.LBL_Seconds.Size = new System.Drawing.Size(49, 13);
            this.LBL_Seconds.TabIndex = 16;
            this.LBL_Seconds.Text = "Seconds";
            this.LBL_Seconds.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LBL_Milliseconds
            // 
            this.LBL_Milliseconds.AutoSize = true;
            this.LBL_Milliseconds.Location = new System.Drawing.Point(225, 28);
            this.LBL_Milliseconds.Name = "LBL_Milliseconds";
            this.LBL_Milliseconds.Size = new System.Drawing.Size(64, 13);
            this.LBL_Milliseconds.TabIndex = 17;
            this.LBL_Milliseconds.Text = "Milliseconds";
            this.LBL_Milliseconds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GB_ClickSelect
            // 
            this.GB_ClickSelect.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GB_ClickSelect.Controls.Add(this.SLDR_ClickType);
            this.GB_ClickSelect.Controls.Add(this.LBL_LClick);
            this.GB_ClickSelect.Controls.Add(this.LBL_LHold);
            this.GB_ClickSelect.Controls.Add(this.LBL_RClick);
            this.GB_ClickSelect.Controls.Add(this.LBL_RHold);
            this.GB_ClickSelect.Controls.Add(this.LBL_MHold);
            this.GB_ClickSelect.Controls.Add(this.LBL_MClick);
            this.GB_ClickSelect.Location = new System.Drawing.Point(6, 12);
            this.GB_ClickSelect.Name = "GB_ClickSelect";
            this.GB_ClickSelect.Size = new System.Drawing.Size(420, 102);
            this.GB_ClickSelect.TabIndex = 18;
            this.GB_ClickSelect.TabStop = false;
            this.GB_ClickSelect.Text = "Click Type";
            // 
            // GB_CInterval
            // 
            this.GB_CInterval.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GB_CInterval.Controls.Add(this.NUD_DelayHours);
            this.GB_CInterval.Controls.Add(this.LBL_Milliseconds);
            this.GB_CInterval.Controls.Add(this.NUD_DelayMinute);
            this.GB_CInterval.Controls.Add(this.LBL_Seconds);
            this.GB_CInterval.Controls.Add(this.NUD_DelaySeconds);
            this.GB_CInterval.Controls.Add(this.LBL_Minutes);
            this.GB_CInterval.Controls.Add(this.NUD_DelayMSeconds);
            this.GB_CInterval.Controls.Add(this.LBL_Hours);
            this.GB_CInterval.Location = new System.Drawing.Point(6, 120);
            this.GB_CInterval.Name = "GB_CInterval";
            this.GB_CInterval.Size = new System.Drawing.Size(305, 86);
            this.GB_CInterval.TabIndex = 19;
            this.GB_CInterval.TabStop = false;
            this.GB_CInterval.Text = "Click Interval";
            // 
            // GB_ReapeatType
            // 
            this.GB_ReapeatType.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GB_ReapeatType.Controls.Add(this.LBL_RTimes);
            this.GB_ReapeatType.Controls.Add(this.LBL_RInfinite);
            this.GB_ReapeatType.Controls.Add(this.SLDR_RepeatType);
            this.GB_ReapeatType.Controls.Add(this.NUD_TimesAmount);
            this.GB_ReapeatType.Enabled = false;
            this.GB_ReapeatType.Location = new System.Drawing.Point(318, 121);
            this.GB_ReapeatType.Name = "GB_ReapeatType";
            this.GB_ReapeatType.Size = new System.Drawing.Size(108, 113);
            this.GB_ReapeatType.TabIndex = 0;
            this.GB_ReapeatType.TabStop = false;
            this.GB_ReapeatType.Text = "Click Repeat";
            this.GB_ReapeatType.Visible = false;
            // 
            // LBL_RTimes
            // 
            this.LBL_RTimes.AutoSize = true;
            this.LBL_RTimes.Location = new System.Drawing.Point(46, 65);
            this.LBL_RTimes.Name = "LBL_RTimes";
            this.LBL_RTimes.Size = new System.Drawing.Size(38, 13);
            this.LBL_RTimes.TabIndex = 16;
            this.LBL_RTimes.Text = "Times:";
            // 
            // LBL_RInfinite
            // 
            this.LBL_RInfinite.AutoSize = true;
            this.LBL_RInfinite.Location = new System.Drawing.Point(46, 26);
            this.LBL_RInfinite.Name = "LBL_RInfinite";
            this.LBL_RInfinite.Size = new System.Drawing.Size(50, 13);
            this.LBL_RInfinite.TabIndex = 15;
            this.LBL_RInfinite.Text = "Indefinite";
            // 
            // SLDR_RepeatType
            // 
            this.SLDR_RepeatType.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SLDR_RepeatType.Location = new System.Drawing.Point(6, 19);
            this.SLDR_RepeatType.Maximum = 1;
            this.SLDR_RepeatType.Name = "SLDR_RepeatType";
            this.SLDR_RepeatType.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.SLDR_RepeatType.Size = new System.Drawing.Size(45, 67);
            this.SLDR_RepeatType.TabIndex = 14;
            this.SLDR_RepeatType.TabStop = false;
            this.SLDR_RepeatType.Value = 1;
            this.SLDR_RepeatType.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // NUD_TimesAmount
            // 
            this.NUD_TimesAmount.Location = new System.Drawing.Point(35, 87);
            this.NUD_TimesAmount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUD_TimesAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_TimesAmount.Name = "NUD_TimesAmount";
            this.NUD_TimesAmount.Size = new System.Drawing.Size(67, 20);
            this.NUD_TimesAmount.TabIndex = 2;
            this.NUD_TimesAmount.TabStop = false;
            this.NUD_TimesAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // UIWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(434, 246);
            this.Controls.Add(this.GB_ReapeatType);
            this.Controls.Add(this.BTN_HotkeyEdit);
            this.Controls.Add(this.GB_CInterval);
            this.Controls.Add(this.GB_ClickSelect);
            this.Controls.Add(this.BTN_StartStop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "UIWindow";
            this.ShowIcon = false;
            this.Text = "AutoClicker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UIWindow_FormClosing);
            this.Load += new System.EventHandler(this.UIWindo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UIWindow_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DelayHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DelayMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DelaySeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DelayMSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SLDR_ClickType)).EndInit();
            this.GB_ClickSelect.ResumeLayout(false);
            this.GB_ClickSelect.PerformLayout();
            this.GB_CInterval.ResumeLayout(false);
            this.GB_CInterval.PerformLayout();
            this.GB_ReapeatType.ResumeLayout(false);
            this.GB_ReapeatType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SLDR_RepeatType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_TimesAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown NUD_DelayHours;
        private System.Windows.Forms.NumericUpDown NUD_DelayMinute;
        private System.Windows.Forms.NumericUpDown NUD_DelaySeconds;
        private System.Windows.Forms.NumericUpDown NUD_DelayMSeconds;
        private System.Windows.Forms.Button BTN_StartStop;
        private System.Windows.Forms.Button BTN_HotkeyEdit;
        private System.Windows.Forms.TrackBar SLDR_ClickType;
        private System.Windows.Forms.Label LBL_LClick;
        private System.Windows.Forms.Label LBL_LHold;
        private System.Windows.Forms.Label LBL_RClick;
        private System.Windows.Forms.Label LBL_RHold;
        private System.Windows.Forms.Label LBL_MClick;
        private System.Windows.Forms.Label LBL_MHold;
        private System.Windows.Forms.Label LBL_Hours;
        private System.Windows.Forms.Label LBL_Minutes;
        private System.Windows.Forms.Label LBL_Seconds;
        private System.Windows.Forms.Label LBL_Milliseconds;
        private System.Windows.Forms.GroupBox GB_ClickSelect;
        private System.Windows.Forms.GroupBox GB_CInterval;
        private System.Windows.Forms.GroupBox GB_ReapeatType;
        private System.Windows.Forms.NumericUpDown NUD_TimesAmount;
        private System.Windows.Forms.Label LBL_RTimes;
        private System.Windows.Forms.Label LBL_RInfinite;
        private System.Windows.Forms.TrackBar SLDR_RepeatType;
    }
}

