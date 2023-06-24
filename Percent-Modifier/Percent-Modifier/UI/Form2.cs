using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Percent_Modifier {
    public partial class Form2 : Form {
        public Form2() {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e) {
            #region Color
            ChangeIndex.BackColor = Color.LightGray;
            ClearIndex.BackColor = Color.LightGray;
            EditIndex.BackColor = Color.LightGray;
            NewIndex.BackColor = Color.LightGray;

            SaveData.BackColor = Color.LightGray;
            LoadData.BackColor = Color.LightGray;
            EditData.BackColor = Color.LightGray;

            Save.BackColor = Color.LightBlue;
            Exit.BackColor = Color.LightCoral;
            #endregion
            checkBox1.Checked = Settings.AddToIndex;
            numericUpDown1.Value = Settings.StackSize;
            textBox1.Text = Settings.IndexPath;
            
        }
        private void ChangeIndex_Click(object sender, EventArgs e) {

        }
        private void ClearIndex_Click(object sender, EventArgs e) {

        }
        private void EditIndex_Click(object sender, EventArgs e) {

        }
        private void NewIndex_Click(object sender, EventArgs e) {

        }

        private void SaveData_Click(object sender, EventArgs e) {

        }
        private void LoadData_Click(object sender, EventArgs e) {

        }
        private void EditData_Click(object sender, EventArgs e) {

        }

        private void Save_Click(object sender, EventArgs e) {
            Settings.SettingsXML.DocumentElement.ChildNodes[0].InnerText = checkBox1.Checked.ToString();
            Settings.SettingsXML.DocumentElement.ChildNodes[1].InnerText = numericUpDown1.Value.ToString();
            Settings.SettingsXML.DocumentElement.ChildNodes[2].InnerText = $@"{textBox1.Text}";
            Settings.SettingsXML.Save(Settings.SettingsPath);
            Settings.Set();
        }
        private void Exit_Click(object sender, EventArgs e) {
            if (checkBox1.Checked != Settings.AddToIndex ||
                    numericUpDown1.Value != Settings.StackSize ||
                        textBox1.Text != Settings.IndexPath) {
                DialogResult Result = MessageBox.Show("You Have Unsaved Changes!"+Environment.NewLine
                    + "Would You Like to Save and Exit?", "Unsaved Changes!", MessageBoxButtons.YesNoCancel, 
                    MessageBoxIcon.Exclamation);
                if (Result== DialogResult.Yes) {
                    Save_Click(sender, e);
                }
                else if (Result == DialogResult.Cancel) {
                    return;
                }
                this.Close();
            }
            this.Close();
        }
    }
}
