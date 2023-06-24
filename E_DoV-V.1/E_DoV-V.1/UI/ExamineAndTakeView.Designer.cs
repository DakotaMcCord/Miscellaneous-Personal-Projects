namespace E_DoV_V._1 {
    partial class ExamineAndTakeView {
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
            this.label1 = new System.Windows.Forms.Label();
            this.ItemListBox = new System.Windows.Forms.ListBox();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.TakeButton = new System.Windows.Forms.Button();
            this.TakeAllButton = new System.Windows.Forms.Button();
            this.CountBox = new System.Windows.Forms.NumericUpDown();
            this.DoneButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.YourInventoryLBL = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CountBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select an Item to Examine or Take.";
            // 
            // ItemListBox
            // 
            this.ItemListBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ItemListBox.FormattingEnabled = true;
            this.ItemListBox.Location = new System.Drawing.Point(12, 25);
            this.ItemListBox.Name = "ItemListBox";
            this.ItemListBox.Size = new System.Drawing.Size(182, 212);
            this.ItemListBox.TabIndex = 1;
            this.ItemListBox.SelectedIndexChanged += new System.EventHandler(this.ItemListBox_SelectedIndexChanged);
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DescriptionBox.Enabled = false;
            this.DescriptionBox.Location = new System.Drawing.Point(200, 25);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.ReadOnly = true;
            this.DescriptionBox.Size = new System.Drawing.Size(242, 212);
            this.DescriptionBox.TabIndex = 2;
            // 
            // TakeButton
            // 
            this.TakeButton.Location = new System.Drawing.Point(3, 3);
            this.TakeButton.Name = "TakeButton";
            this.TakeButton.Size = new System.Drawing.Size(56, 23);
            this.TakeButton.TabIndex = 3;
            this.TakeButton.Text = "Take";
            this.TakeButton.UseVisualStyleBackColor = true;
            this.TakeButton.Click += new System.EventHandler(this.TakeButton_Click);
            // 
            // TakeAllButton
            // 
            this.TakeAllButton.Location = new System.Drawing.Point(119, 3);
            this.TakeAllButton.Name = "TakeAllButton";
            this.TakeAllButton.Size = new System.Drawing.Size(56, 23);
            this.TakeAllButton.TabIndex = 5;
            this.TakeAllButton.Text = "Take All";
            this.TakeAllButton.UseVisualStyleBackColor = true;
            this.TakeAllButton.Click += new System.EventHandler(this.TakeAllButton_Click);
            // 
            // CountBox
            // 
            this.CountBox.Location = new System.Drawing.Point(65, 5);
            this.CountBox.Name = "CountBox";
            this.CountBox.Size = new System.Drawing.Size(48, 20);
            this.CountBox.TabIndex = 6;
            // 
            // DoneButton
            // 
            this.DoneButton.Location = new System.Drawing.Point(182, 3);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(56, 23);
            this.DoneButton.TabIndex = 7;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.TakeButton);
            this.panel1.Controls.Add(this.DoneButton);
            this.panel1.Controls.Add(this.TakeAllButton);
            this.panel1.Controls.Add(this.CountBox);
            this.panel1.Location = new System.Drawing.Point(200, 246);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 30);
            this.panel1.TabIndex = 8;
            // 
            // LogBox
            // 
            this.LogBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LogBox.Enabled = false;
            this.LogBox.Location = new System.Drawing.Point(12, 243);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(182, 33);
            this.LogBox.TabIndex = 9;
            this.LogBox.TextChanged += new System.EventHandler(this.LogBox_TextChanged);
            // 
            // YourInventoryLBL
            // 
            this.YourInventoryLBL.AutoSize = true;
            this.YourInventoryLBL.Location = new System.Drawing.Point(224, 9);
            this.YourInventoryLBL.Name = "YourInventoryLBL";
            this.YourInventoryLBL.Size = new System.Drawing.Size(35, 13);
            this.YourInventoryLBL.TabIndex = 10;
            this.YourInventoryLBL.Text = "label2";
            // 
            // ExamineAndTakeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(447, 286);
            this.ControlBox = false;
            this.Controls.Add(this.YourInventoryLBL);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.ItemListBox);
            this.Controls.Add(this.label1);
            this.Name = "ExamineAndTakeView";
            this.ShowIcon = false;
            this.Text = "Examine or Take Item";
            this.Load += new System.EventHandler(this.ExamineView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CountBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox ItemListBox;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.Button TakeButton;
        private System.Windows.Forms.Button TakeAllButton;
        private System.Windows.Forms.NumericUpDown CountBox;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.Label YourInventoryLBL;
    }
}