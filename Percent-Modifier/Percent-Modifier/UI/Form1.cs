using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Xml;
using System.IO;

namespace Percent_Modifier {
    public partial class Form1 : Form {
        #region Variables
        string
            Buff = "Buff (+)",
            Debuff = "Debuff (-)";
        double
            Ammount,
            Count,

            LeftPercent,
            RightPercent,
            LeftActual,
            RightActual;
        #endregion

        public Form1() {
            InitializeComponent();
            Settings.Set();
        }
        private void Form1_Load(object sender, EventArgs e) {
            #region Instantiate Columns
            DataGridViewTextBoxColumn Modifier = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Type = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Ammount = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Multiplier = new DataGridViewTextBoxColumn();
            DataGridViewButtonColumn Btn = new DataGridViewButtonColumn();
            DataGridViewButtonColumn Btn2 = new DataGridViewButtonColumn();

            Modifier.HeaderText = "Modifier";
            Type.HeaderText = "Type";
            Ammount.HeaderText = "Ammount";
            Multiplier.HeaderText = "Multiplier";
            Btn.HeaderText = "Delete All";
            Btn2.HeaderText = "Delete One";

            Btn.UseColumnTextForButtonValue = true;
            Btn.Text = Btn.HeaderText;
            Btn2.UseColumnTextForButtonValue = true;
            Btn2.Text = Btn2.HeaderText;

            dataGridView1.Columns.Add(Modifier);
            dataGridView1.Columns.Add(Type);
            dataGridView1.Columns.Add(Ammount);
            dataGridView1.Columns.Add(Multiplier);
            dataGridView1.Columns.Add(Btn);
            dataGridView1.Columns.Add(Btn2);

            Modifier.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //Type.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Type.Width = 60;
            Ammount.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Multiplier.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //Btn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Btn.Width = 70;
            Btn2.Width = 70;

            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            #endregion

            progressBar1.ForeColor = Settings.BarBuffColour;
            progressBar2.ForeColor = Settings.BarDebuffColour;
            progressBar1.BackColor = Color.LightGray;
            progressBar2.BackColor = Color.LightGray;

            comboBox1.SelectedIndex = 0;
            button1.Text = "Add Modifier";
            button2.Text = "Reset";

            button1.BackColor = Color.LightGray;
            button2.BackColor = Color.LightGray;
            button3.BackColor = Color.LightGray;

            #region Tab Info
            dataGridView1.TabStop = false;
            button2.TabStop = false;
            textBox1.TabIndex = 1;
            comboBox1.TabIndex = 2;
            textBox2.TabIndex = 3;
            textBox3.TabIndex = 4;
            #endregion
        }

        #region DataGrid Info
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if (dataGridView1.CurrentCell.RowIndex == dataGridView1.Rows.Count - 1) {
                    MessageBox.Show("You Cannot Delete This Row");
                }
                else if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns.Count - 2) {
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                } else if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns.Count - 1) {
                    DataGridViewRow Row = dataGridView1.CurrentRow;
                    if (Double.Parse(Row.Cells[3].Value.ToString()) > 1) {
                        double N = Double.Parse(Row.Cells[3].Value.ToString()) - 1;
                        Row.Cells[3].Value = N.ToString();
                    } else {
                        dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                    }
                }
            } catch {
                //do Nothing
            }
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            Calibrate();
        }
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) {
            Calibrate();
        }
        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e) {
            Calibrate();
        }
        private void Calibrate() {
            LeftActual = 0;
            RightActual = 0;
            Top:
            foreach (DataGridViewRow Row in dataGridView1.Rows) {
                if (Row.Index != dataGridView1.Rows.Count - 1) {
                    if (Row.Cells[2].Value.ToString() == "0" || Row.Cells[3].Value.ToString() == "0") {
                        dataGridView1.Rows.Remove(Row);
                        goto Top;
                    }

                    if (Row.Cells[1].Value.ToString() == Buff) {
                        Row.DefaultCellStyle.BackColor = Settings.BuffColour;
                        LeftActual += Double.Parse(Row.Cells[2].Value.ToString()) * Double.Parse(Row.Cells[3].Value.ToString());
                    }
                    else if (Row.Cells[1].Value.ToString() == Debuff) {
                        Row.DefaultCellStyle.BackColor = Settings.DebuffColour;
                        RightActual += Double.Parse(Row.Cells[2].Value.ToString()) * Double.Parse(Row.Cells[3].Value.ToString());
                    }
                    Row.Cells[4].Style.BackColor = Color.LightGray;
                    Row.Cells[5].Style.BackColor = Color.LightGray;
                }
            }
            label3.Text = LeftActual.ToString();
            label4.Text = RightActual.ToString();

            LeftPercent = Math.Round(((LeftActual * 100) / (LeftActual + RightActual)), 2);
            RightPercent = Math.Round(((RightActual * 100) / (LeftActual + RightActual)), 2);

            label1.Text = $"{LeftPercent}%";
            label2.Text = $"{RightPercent}%";

            if (label1.Text != "NaN%") {
                progressBar1.Value = (int)Math.Round(LeftPercent);
                progressBar2.Value = (int)Math.Round(RightPercent);
            } else {
                progressBar1.Value = 100;
                progressBar2.Value = 100;
            }
        }
        #endregion
        #region Text Changed
        private void textBox2_TextChanged(object sender, EventArgs e) {
            Rules(textBox2);
        }
        private void textBox3_TextChanged(object sender, EventArgs e) {
            Rules(textBox3);
        }
        #endregion
        #region Enter = Tab
        private void textBox1_KeyDown(object sender, KeyEventArgs e) {
            Rules2(e);
        }
        private void comboBox1_KeyDown(object sender, KeyEventArgs e) {
            Rules2(e);
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e) {
            Rules2(e);
        }
        private void textBox3_KeyDown(object sender, KeyEventArgs e) {
            Rules2(e);
        }
        private void button1_KeyDown(object sender, KeyEventArgs e) {
            button1_Click(sender, e);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e) {
            string Check = "";
            if (textBox1.Text != "" && comboBox1.SelectedIndex != 0 && textBox2.Text != "" && textBox3.Text != "") {
                try {
                    //Rules(textBox2);
                    Check = Rules(textBox2);
                    if (Check == "1" ) {
                        return;
                    }
                    //Rules(textBox3);
                    Check = Rules(textBox3);
                    if (Check == "2") {
                        return;
                    }

                    Ammount = Double.Parse(textBox2.Text);
                    Count = Double.Parse(textBox3.Text);

                    if (Ammount == 0 || Count == 0) {
                        //Rules(textBox2);
                        Check = Rules(textBox2);
                        if (Check == "1") {
                            return;
                        }
                        Rules(textBox3);
                        //Check = Rules(textBox3);
                        if (Check == "2") {
                            return;
                        }
                        MessageBox.Show("Fields 3 & 4 Cannot be Equal to 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                } catch {
                    Rules(textBox2);
                    Check = Rules(textBox2);
                    if (Check == "1" ) {
                        return;
                    }
                    Rules(textBox3);
                    Check = Rules(textBox3);
                    if (Check == "2") {
                        return;
                    }
                }

                foreach (DataGridViewRow Row in dataGridView1.Rows) {
                    if (Row.Index != dataGridView1.RowCount - 1) {
                        if (textBox1.Text == Row.Cells[0].Value.ToString() &&
                            comboBox1.SelectedItem.ToString() == Row.Cells[1].Value.ToString() &&
                                textBox2.Text == Row.Cells[2].Value.ToString()) {
                            if (Settings.StackSize == 0 || Double.Parse(Row.Cells[3].Value.ToString()) < Settings.StackSize) {
                                double N = Double.Parse(Row.Cells[3].Value.ToString()) + Double.Parse(textBox3.Text);
                                Row.Cells[3].Value = N;
                                return;
                            }
                        }
                    }
                }
                dataGridView1.Rows.Add(textBox1.Text, comboBox1.Text, Ammount, Count);
            }
            else {
                MessageBox.Show("All fields must be Completed", "Information Needed", MessageBoxButtons.OK);
            }
        }
        private void button2_Click(object sender, EventArgs e) {
            DialogResult Result = MessageBox.Show($"Are You Sure You want To Clear The Current Data?{Environment.NewLine}" +
                $"Once Cleared, it Cannot be Undone!", "Confirmation Required.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Result == DialogResult.Yes) {
                dataGridView1.Rows.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            Form2 form2 = new Form2();
            form2.ShowDialog();

            Top:
            foreach (DataGridViewRow Row in dataGridView1.Rows) {
                if (Row.Index != dataGridView1.RowCount - 1 ) {
                    foreach (DataGridViewRow RowCheck in dataGridView1.Rows) {
                        if (RowCheck.Index != dataGridView1.RowCount - 1 && (RowCheck.Index != Row.Index)) {
                            if (Row.Cells[0].Value.ToString() == RowCheck.Cells[0].Value.ToString() && 
                                Row.Cells[1].Value.ToString() == RowCheck.Cells[1].Value.ToString() &&
                                Row.Cells[2].Value.ToString() == RowCheck.Cells[2].Value.ToString()) {
                                double N = Double.Parse(RowCheck.Cells[3].Value.ToString());
                                Row.Cells[3].Value = (Double.Parse(Row.Cells[3].Value.ToString()) + N);
                                dataGridView1.Rows.Remove(RowCheck);
                                goto Top;
                            }
                        }
                    }
                }
            }
            foreach (DataGridViewRow Row in dataGridView1.Rows) {
                if (Row.Index != dataGridView1.RowCount - 1) {
                    if (Settings.StackSize != 0) {
                        while (Double.Parse(Row.Cells[3].Value.ToString()) > Settings.StackSize) {
                            double N = Double.Parse(Row.Cells[3].Value.ToString()) - Settings.StackSize;
                            Row.Cells[3].Value = N;
                            dataGridView1.Rows.Add(Row.Cells[0].Value, Row.Cells[1].Value, Row.Cells[2].Value, Settings.StackSize);
                        }
                    }
                }
            }
        }

        string Text = "";
        private string Rules(TextBox textBox) {
            if (textBox.Text.Count() < Text.Count()) {
                Text = textBox.Text;
                return null;
            }
            Text = textBox.Text;

            int n = 0;
            foreach (char i in textBox.Text) {
                if (i.ToString() == ".") {
                    n++;
                    if (n > 1) {
                        MessageBox.Show("There cannot be more than one '.' here.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
                //try {
                //    if (textBox.Text.Count() < Text.Count()) {
                //        Text = textBox.Text;
                //        return null;
                //    }
                //    Text = textBox.Text;
                //    Int32.Parse(i.ToString());
                //}
                //catch {
                //    MessageBox.Show("Fields 3 & 4 Cannot contain Text.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    if (textBox == textBox2) {
                //        return "1";
                //    }
                //    else if (textBox == textBox3) {
                //        return "2";
                //    }
                //}
            }
            return null;
        }
        private void Rules2(KeyEventArgs E) {
            if (E.KeyCode == Keys.Enter) {
                E.Handled = true;
                E.SuppressKeyPress = true;

                this.ProcessTabKey(true);
            }
        }
    }
}