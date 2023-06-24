using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator {
    public partial class FM_Calculator : Form {
        #region Core
        public FM_Calculator() {
            InitializeComponent();
        }

        List<Keys> AllowKeys = new List<Keys>();
        int caretintex, MTxtLength = 30;

        private void FM_Calculator_Load(object sender, EventArgs e) {
            this.ControlBox = true;
            this.Text = "Calculator";
            this.Height = 350;
            this.Width = 300;
            this.MaximumSize = this.Size;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.BackColor = Color.FromArgb(255, 100, 100, 100);
            this.ShowIcon = false;

            PNL_Numberpad.BackColor = Color.FromArgb(255, 150, 150, 150);
            PNL_Numberpad.ForeColor = Color.Black;

            TBX_MathView.BackColor = Color.Silver;
            TBX_MathView.Font = new Font("Comic Sans MS", 20f, FontStyle.Regular, GraphicsUnit.Point);

            #region AllowKeys
            //AllowKeys.Add(Keys.Enter);
            AllowKeys.Add(Keys.Back);
            AllowKeys.Add(Keys.OemPeriod);
            AllowKeys.Add(Keys.Multiply);
            AllowKeys.Add(Keys.OemQuestion);
            AllowKeys.Add(Keys.Oemplus);
            AllowKeys.Add(Keys.OemMinus);

            AllowKeys.Add(Keys.Up);
            AllowKeys.Add(Keys.Left);
            AllowKeys.Add(Keys.Down);
            AllowKeys.Add(Keys.Right);

            AllowKeys.Add(Keys.D0);
            AllowKeys.Add(Keys.NumPad0);
            AllowKeys.Add(Keys.D1);
            AllowKeys.Add(Keys.NumPad1);
            AllowKeys.Add(Keys.D2);
            AllowKeys.Add(Keys.NumPad2);
            AllowKeys.Add(Keys.D3);
            AllowKeys.Add(Keys.NumPad3);
            AllowKeys.Add(Keys.D4);
            AllowKeys.Add(Keys.NumPad4);
            AllowKeys.Add(Keys.D5);
            AllowKeys.Add(Keys.NumPad5);
            AllowKeys.Add(Keys.D6);
            AllowKeys.Add(Keys.NumPad6);
            AllowKeys.Add(Keys.D7);
            AllowKeys.Add(Keys.NumPad7);
            AllowKeys.Add(Keys.D8);
            AllowKeys.Add(Keys.NumPad8);
            AllowKeys.Add(Keys.D9);
            AllowKeys.Add(Keys.NumPad9);
            #endregion
        } // Load Form
        private void TBX_MathView_KeyDown(object sender, KeyEventArgs e) {
            Keys K = e.KeyCode;
            if (K == Keys.Enter) {
                e.Handled = true;
                e.SuppressKeyPress = true;
                DotheMath();
            } else if (K == Keys.C) {
                e.Handled = true;
                e.SuppressKeyPress = true;
                ClearBox();
            } else if (!AllowKeys.Contains(K)) {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            UpdateCaret();
        } // Keydown Events - Disable invalid Keys
        private void TBX_MathView_TextChanged(object sender, EventArgs e) {
            if(TBX_MathView.Text.Contains("_")) {
                TBX_MathView.Text = TBX_MathView.Text.Replace("_", "-");
                TBX_MathView.Select(TBX_MathView.Text.Length, 0);
            }
            if (TBX_MathView.Text.Contains("=")) {
                TBX_MathView.Text = TBX_MathView.Text.Replace("=", "+");
                TBX_MathView.Select(TBX_MathView.Text.Length, 0);
            }
            if (TBX_MathView.Text.Contains("?")) {
                TBX_MathView.Text = TBX_MathView.Text.Replace("?", "/");
                TBX_MathView.Select(TBX_MathView.Text.Length, 0);
            }
        } // Text Changed
        private void TBX_MathView_MouseClick(object sender, MouseEventArgs e) {
            UpdateCaret();
        } // Mous Click event on box



        public void DotheMath() {
            // P E M D A S
            string Problem = TBX_MathView.Text;

            try {
                DataTable table = new DataTable();
                var ProblemOutput = table.Compute(Problem, "");

                TBX_MathView.Text = ProblemOutput.ToString();
                TBX_MathView.Select(TBX_MathView.Text.Length, 0);
            }
            catch {
                MessageBox.Show(
                    $"An Unexpected error has ocured. {Environment.NewLine}" +
                    $"Please verify there are no typos.", "Err", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }






        }
        #endregion
        #region Special
        private void BTN_Back_Click(object sender, EventArgs e) {
            if (TBX_MathView.Text != string.Empty) {
                TBX_MathView.Text = TBX_MathView.Text.Remove(TBX_MathView.Text.Length - 1, 1);
                TBX_MathView.Select(TBX_MathView.Text.Length, 0);
            }
            SelectCalcView();
        } // Back
        private void BTN_Clear_Click(object sender, EventArgs e) {
            ClearBox();
        }// Clear
                    public void ClearBox() {
                        TBX_MathView.Text = string.Empty;
                        SelectCalcView();
                    } // Clears Box
        private void BTN_Point_Click(object sender, EventArgs e) {
            TBX_MathView.Text = TBX_MathView.Text.Insert(TBX_MathView.SelectionStart, ".");
            SelectCalcView();
        } // Point
        private void BTN_PLeft_Click(object sender, EventArgs e) {
            TBX_MathView.Text = TBX_MathView.Text.Insert(TBX_MathView.SelectionStart, "(");
            SelectCalcView();
        } // Pleft
        private void BTN_PRight_Click(object sender, EventArgs e) {
            TBX_MathView.Text = TBX_MathView.Text.Insert(TBX_MathView.SelectionStart, ")");
            SelectCalcView();
        } // Pright

        private void BTN_Enter_Click(object sender, EventArgs e) {
            DotheMath();
            SelectCalcView();
        }
        #endregion
        #region Numbers
        private void BTN_Zero_Click(object sender, EventArgs e) {
            TBX_MathView.Text = TBX_MathView.Text.Insert(TBX_MathView.SelectionStart, "0");
            SelectCalcView();
        }
        private void BTN_One_Click(object sender, EventArgs e) {
            TBX_MathView.Text = TBX_MathView.Text.Insert(TBX_MathView.SelectionStart, "1");
            SelectCalcView();
        }
        private void BTN_Two_Click(object sender, EventArgs e) {
            TBX_MathView.Text = TBX_MathView.Text.Insert(TBX_MathView.SelectionStart, "2");
            SelectCalcView();
        }
        private void BTN_Three_Click(object sender, EventArgs e) {
            TBX_MathView.Text = TBX_MathView.Text.Insert(TBX_MathView.SelectionStart, "3");
            SelectCalcView();
        }
        private void BTN_Four_Click(object sender, EventArgs e) {
            TBX_MathView.Text = TBX_MathView.Text.Insert(TBX_MathView.SelectionStart, "4");
            SelectCalcView();
        }
        private void BTN_Five_Click(object sender, EventArgs e) {
            TBX_MathView.Text = TBX_MathView.Text.Insert(TBX_MathView.SelectionStart, "5");
            SelectCalcView();
        }
        private void Btn_Six_Click(object sender, EventArgs e) {
            TBX_MathView.Text = TBX_MathView.Text.Insert(TBX_MathView.SelectionStart, "6");
            SelectCalcView();
        }
        private void BTN_Seven_Click(object sender, EventArgs e) {
            TBX_MathView.Text = TBX_MathView.Text.Insert(TBX_MathView.SelectionStart, "7");
            SelectCalcView();
        }
        private void BTN_Eight_Click(object sender, EventArgs e) {
            TBX_MathView.Text = TBX_MathView.Text.Insert(TBX_MathView.SelectionStart, "8");
            SelectCalcView();
        }
        private void BTN_Nine_Click(object sender, EventArgs e) {
            TBX_MathView.Text = TBX_MathView.Text.Insert(TBX_MathView.SelectionStart, "9");
            SelectCalcView();
        }
        #endregion
        #region Operations
        private void BTN_Plus_Click(object sender, EventArgs e) {
            TBX_MathView.Text = TBX_MathView.Text.Insert(TBX_MathView.SelectionStart, "+");
            SelectCalcView();
        }
        private void BTN_Minus_Click(object sender, EventArgs e) {
            TBX_MathView.Text = TBX_MathView.Text.Insert(TBX_MathView.SelectionStart, "-");
            SelectCalcView();
        }
        private void BTN_Times_Click(object sender, EventArgs e) {
            TBX_MathView.Text = TBX_MathView.Text.Insert(TBX_MathView.SelectionStart, "*");
            SelectCalcView();
        }
        private void BTN_Division_Click(object sender, EventArgs e) {
            TBX_MathView.Text = TBX_MathView.Text.Insert(TBX_MathView.SelectionStart, "/");
            SelectCalcView();
        }
        #endregion
        #region UpdateStuff
        public void UpdateCaret() {
            caretintex = TBX_MathView.SelectionStart;
        } // Update Caret Position
        public void SelectCalcView() {
            TBX_MathView.Focus();
            TBX_MathView.DeselectAll();
            caretintex++;
            TBX_MathView.Select(caretintex, 0);
            
        } // Slect Textbox View
        //public bool StringTooLong() {
        //    if (TBX_MathView.Text.Length >= MTxtLength) {
        //        return true;
        //    }
        //    else { return false; }
        //}
        #endregion
    }
}
