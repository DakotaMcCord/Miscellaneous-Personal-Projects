namespace Percent_Modifier {
    partial class Form2 {
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SaveData = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.LoadData = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ChangeIndex = new System.Windows.Forms.Button();
            this.ClearIndex = new System.Windows.Forms.Button();
            this.NewIndex = new System.Windows.Forms.Button();
            this.EditData = new System.Windows.Forms.Button();
            this.EditIndex = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(22, 44);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(168, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "Add Unique Modifiers to Index";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // SaveData
            // 
            this.SaveData.Location = new System.Drawing.Point(12, 12);
            this.SaveData.Name = "SaveData";
            this.SaveData.Size = new System.Drawing.Size(75, 23);
            this.SaveData.TabIndex = 1;
            this.SaveData.TabStop = false;
            this.SaveData.Text = "Save Data";
            this.SaveData.UseVisualStyleBackColor = true;
            this.SaveData.Click += new System.EventHandler(this.SaveData_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(355, 41);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(47, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.TabStop = false;
            // 
            // LoadData
            // 
            this.LoadData.Location = new System.Drawing.Point(93, 12);
            this.LoadData.Name = "LoadData";
            this.LoadData.Size = new System.Drawing.Size(75, 23);
            this.LoadData.TabIndex = 3;
            this.LoadData.TabStop = false;
            this.LoadData.Text = "Load Data";
            this.LoadData.UseVisualStyleBackColor = true;
            this.LoadData.Click += new System.EventHandler(this.LoadData_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(310, 12);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(40, 23);
            this.Save.TabIndex = 4;
            this.Save.TabStop = false;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(356, 12);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(45, 23);
            this.Exit.TabIndex = 5;
            this.Exit.TabStop = false;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Stack Size ( 0 = Infinite ):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 94);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(389, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.TabStop = false;
            // 
            // ChangeIndex
            // 
            this.ChangeIndex.Location = new System.Drawing.Point(222, 69);
            this.ChangeIndex.Name = "ChangeIndex";
            this.ChangeIndex.Size = new System.Drawing.Size(87, 23);
            this.ChangeIndex.TabIndex = 8;
            this.ChangeIndex.TabStop = false;
            this.ChangeIndex.Text = "Change Index";
            this.ChangeIndex.UseVisualStyleBackColor = true;
            this.ChangeIndex.Click += new System.EventHandler(this.ChangeIndex_Click);
            // 
            // ClearIndex
            // 
            this.ClearIndex.Location = new System.Drawing.Point(315, 69);
            this.ClearIndex.Name = "ClearIndex";
            this.ClearIndex.Size = new System.Drawing.Size(87, 23);
            this.ClearIndex.TabIndex = 9;
            this.ClearIndex.TabStop = false;
            this.ClearIndex.Text = "Clear Index";
            this.ClearIndex.UseVisualStyleBackColor = true;
            this.ClearIndex.Click += new System.EventHandler(this.ClearIndex_Click);
            // 
            // NewIndex
            // 
            this.NewIndex.Location = new System.Drawing.Point(83, 69);
            this.NewIndex.Name = "NewIndex";
            this.NewIndex.Size = new System.Drawing.Size(66, 23);
            this.NewIndex.TabIndex = 10;
            this.NewIndex.TabStop = false;
            this.NewIndex.Text = "New Index";
            this.NewIndex.UseVisualStyleBackColor = true;
            this.NewIndex.Click += new System.EventHandler(this.NewIndex_Click);
            // 
            // EditData
            // 
            this.EditData.Location = new System.Drawing.Point(174, 12);
            this.EditData.Name = "EditData";
            this.EditData.Size = new System.Drawing.Size(68, 23);
            this.EditData.TabIndex = 11;
            this.EditData.TabStop = false;
            this.EditData.Text = "Edit Data";
            this.EditData.UseVisualStyleBackColor = true;
            this.EditData.Click += new System.EventHandler(this.EditData_Click);
            // 
            // EditIndex
            // 
            this.EditIndex.Location = new System.Drawing.Point(12, 69);
            this.EditIndex.Name = "EditIndex";
            this.EditIndex.Size = new System.Drawing.Size(65, 23);
            this.EditIndex.TabIndex = 12;
            this.EditIndex.TabStop = false;
            this.EditIndex.Text = "Edit Index";
            this.EditIndex.UseVisualStyleBackColor = true;
            this.EditIndex.Click += new System.EventHandler(this.EditIndex_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 126);
            this.ControlBox = false;
            this.Controls.Add(this.EditIndex);
            this.Controls.Add(this.EditData);
            this.Controls.Add(this.NewIndex);
            this.Controls.Add(this.ClearIndex);
            this.Controls.Add(this.ChangeIndex);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.LoadData);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.SaveData);
            this.Controls.Add(this.checkBox1);
            this.MaximumSize = new System.Drawing.Size(430, 165);
            this.MinimumSize = new System.Drawing.Size(430, 165);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings & Other";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button SaveData;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button LoadData;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ChangeIndex;
        private System.Windows.Forms.Button ClearIndex;
        private System.Windows.Forms.Button NewIndex;
        private System.Windows.Forms.Button EditData;
        private System.Windows.Forms.Button EditIndex;
    }
}