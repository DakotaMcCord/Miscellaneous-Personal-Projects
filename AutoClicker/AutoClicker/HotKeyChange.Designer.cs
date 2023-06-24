
namespace AutoClicker {
    partial class HotKeyChange {
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
            this.BTN_ChangeHotKey = new System.Windows.Forms.Button();
            this.BTN_Close = new System.Windows.Forms.Button();
            this.LBL_Header = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BTN_ChangeHotKey
            // 
            this.BTN_ChangeHotKey.Location = new System.Drawing.Point(58, 44);
            this.BTN_ChangeHotKey.Name = "BTN_ChangeHotKey";
            this.BTN_ChangeHotKey.Size = new System.Drawing.Size(149, 50);
            this.BTN_ChangeHotKey.TabIndex = 0;
            this.BTN_ChangeHotKey.TabStop = false;
            this.BTN_ChangeHotKey.Text = "button1";
            this.BTN_ChangeHotKey.UseVisualStyleBackColor = true;
            this.BTN_ChangeHotKey.Click += new System.EventHandler(this.BTN_ChangeHotKey_Click);
            this.BTN_ChangeHotKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BTN_ChangeHotKey_KeyDown);
            // 
            // BTN_Close
            // 
            this.BTN_Close.Location = new System.Drawing.Point(97, 100);
            this.BTN_Close.Name = "BTN_Close";
            this.BTN_Close.Size = new System.Drawing.Size(72, 23);
            this.BTN_Close.TabIndex = 2;
            this.BTN_Close.Text = "Close";
            this.BTN_Close.UseVisualStyleBackColor = true;
            this.BTN_Close.Click += new System.EventHandler(this.BTN_Close_Click);
            // 
            // LBL_Header
            // 
            this.LBL_Header.AutoSize = true;
            this.LBL_Header.Location = new System.Drawing.Point(6, 17);
            this.LBL_Header.Name = "LBL_Header";
            this.LBL_Header.Size = new System.Drawing.Size(261, 13);
            this.LBL_Header.TabIndex = 3;
            this.LBL_Header.Text = "Press the button and then the key you want to assign.";
            // 
            // HotKeyChange
            // 
            this.AcceptButton = this.BTN_Close;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(272, 143);
            this.ControlBox = false;
            this.Controls.Add(this.LBL_Header);
            this.Controls.Add(this.BTN_Close);
            this.Controls.Add(this.BTN_ChangeHotKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HotKeyChange";
            this.ShowIcon = false;
            this.Text = "HotKeyChange";
            this.Load += new System.EventHandler(this.HotKeyChange_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_ChangeHotKey;
        private System.Windows.Forms.Button BTN_Close;
        private System.Windows.Forms.Label LBL_Header;
    }
}