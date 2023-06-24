using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;

namespace FileIO_Test_002 {
    public partial class Form1 : Form {
        #region Var
        string Path = @"\Indices\DefaultIndex.txt";
        string CD = Directory.GetCurrentDirectory().ToString();
        string CodePath;
        string H = "";
        string[] H2;
        DialogResult a;
        string CustomPath = @"";
        List<index> Index = new List<index>();
        List<string> Hold = new List<string>();
        #endregion
        public Form1() {
            InitializeComponent();
            CodePath = CD + Path;
        }
        private void Form1_Load(object sender, EventArgs e) {
            //textBox1.Text += CodePath;
            LoadIndex();
        } // form 1 loader

        public void button1_Click(object sender, EventArgs e) {
            if (textBox1.Text == "") {
                MessageBox.Show("You must type some text into the Upper Box before you can Convert it.");
            }
            else {
                Hold.Clear();
                foreach (char i in textBox1.Text) {
                    Hold.Add(i.ToString());
            }
                Clear2();
                foreach (string i in Hold) {
                    foreach (index I in Index) {
                        if (I.English == i) {
                            textBox2.Text += $"{I.Code} ";
                        }
                    } // Foreach in Index
                } //for each In Hold
            } // else
        } // To Code
        public void button3_Click(object sender, EventArgs e) {
            if (textBox2.Text == "") {
                MessageBox.Show($"You must type some Code into the Lower Box before you can Convert it.");
            }
            else {
                Hold.Clear();
                H = textBox2.Text;
                H2 = H.Split(' ');
                Clear1();
                int x = -1;
                foreach (string i in H2) {
                    foreach (index I in Index) {
                        if (I.Code == i) {
                            textBox1.Text += $"{I.English}";
                        }
                        else if (i == " ") {
                            textBox2.Text += $"";
                        }
                    } // Foreach in Index
                } //for each In Hold
            } // else
        } // to Text

        private void button2_Click(object sender, EventArgs e) {
            Application.Exit();
        } // exit button

        private void button4_Click(object sender, EventArgs e) {
            Clear1();
        } // Clear Top
        private void button5_Click(object sender, EventArgs e) {
            Clear2();
        } // Clear Button
        private void button6_Click(object sender, EventArgs e) {
            Clear1();
            Clear2();
        } // Clear All

        private void Clear1() {
            textBox1.Text = "";
        }
        private void Clear2() {
            textBox2.Text = "";
        }

        private void button7_Click(object sender, EventArgs e) {
            MessageBox.Show(
                "In the Default Application Version:\n  Use ( * ) for Dots, and ( - ) for Dashes\n  " +
                  "e.g: ( *- ) is equivelent to ( A )\n\n" +
                
                "Use ( || ) to denote spaces in the code\n" +
                "Use a space between segments of the code to Denote Characters:\n  " +
                  "e.g: (*- || *-) = (A A)\n\n" +
                
                "Do NOT use ( . ) - May Crash Program\n" +
                "All other Special Characters are Represented by themselves\n" +
                "--------------------------------------------------------------------------\n" +

                "If You would Like to Create your Own Index or Code:\n\n" +
                "Then Create a File or add to the default 'DefaultIndex.txt' file,\n  " +
                  "Start by adding a single digit Character ( a )\n  " +
                  "then a Full stop ( . ), Fallowed by the desired Code ( *- )  \n\n" +
                  "You Should Get ( a.*- ), Which You can Find in the Default Index.\n" +
                "So Now You can Go and create your Own Code!","Help",MessageBoxButtons.OK, MessageBoxIcon.Question);
        } // Help
        
        private void button8_Click(object sender, EventArgs e) {
            H = "";
            Hold.Clear();
        Top:
            string CustomPath = @"";
            DialogResult M;

            CustomPath = Interaction.InputBox("Input the file path of the text file here:\n  " +
                @"eg: C:\Users\Person\Text.txt", "Import File:");
            if (CustomPath != "") {
                if (File.Exists(CustomPath)) {
                    MessageBox.Show($"'{CustomPath}' Has Been Loaded!", "Success!");
                    Hold = File.ReadAllLines(CustomPath).ToList();
                    foreach (string i in Hold) {
                        H += i;
                    }
                    textBox2.Text = H;
                }
                else {
                    M = MessageBox.Show($"'{CustomPath}' Could Not be Found", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (M == DialogResult.Retry) {
                        goto Top;
                    }
                }
            }
        } // Import
        private void button9_Click(object sender, EventArgs e) {
            H = "";
            Hold.Clear();
        Top:
            CustomPath = Interaction.InputBox("Input the file path of the text file you would like to print to here:\n  " +
                @"eg: C:\Users\Person\Text.txt", "Import File:");
            if (CustomPath != "") {
                if (File.Exists(CustomPath)) {
                    MessageBox.Show($"'{CustomPath}' Has Been writen Too", "Success!");
                    H = textBox2.Text;
                    File.AppendAllText(CustomPath, H);
                }
                else {
                    a = MessageBox.Show($"'{CustomPath}' Could Not be Found", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (a == DialogResult.Retry) {
                        goto Top;
                    }
                }
            }
        } // Export

        private void button10_Click(object sender, EventArgs e) {
            CustomeLoad();
        } // Custom Load

        private void CustomeLoad(){
            Tryagain:
            CodePath = Interaction.InputBox("Input the file path of Your Index here:\n  " +
                @"eg: C:\Users\Person\Text.txt", "Import File:",CD+Path);
            if (CodePath != "") {
                if (File.Exists(CodePath)) {
                    MessageBox.Show($"'{CodePath}' Has Been Loaded!", "Success!");
                    LoadIndex();
                }
                else {
                    a = MessageBox.Show($"{CodePath} was not Found,\nWould You Like to Try Again?", "Load Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (a == DialogResult.Yes) {
                        goto Tryagain;
                    }
                }
            }
        } // Custome Load
        private void LoadIndex() {
            if (File.Exists(CodePath)) {
                Hold = File.ReadAllLines(CodePath).ToList();
                try {
                    Index.Clear();
                    foreach (string line in Hold) {
                        string[] entries = line.Split('.');

                        index I = new index();
                        I.English = entries[0];
                        I.Code = entries[1];

                        Index.Add(I);
                    } // Create Index
                }
                catch {
                    a = MessageBox.Show($"There Was an Error Reading {CodePath}\n" +
                        $"You Can Can select 'Retry' to Load a Different File, or 'Cancle' to Exit", "Critical Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (a == DialogResult.Retry) {
                        CustomeLoad();
                    } else {
                        Application.Exit();
                    }
                }
            }
            else {
            Top:
                a = MessageBox.Show($"{CodePath} was not Found,\nWould You Like to Imput the Index's File Path?", "Load Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (a == DialogResult.Yes) {
                    Top2:
                    CodePath = Interaction.InputBox("Input the file path of Your Index here:\n  " +
                        @"eg: C:\Users\Person\Text.txt", "Import File:", CD+Path);
                    if (File.Exists(CodePath)) {
                        LoadIndex();
                    }
                    else if (CodePath == "") {
                        if (MessageBox.Show($"Canceling without entering a Filepath will Close the Program!.\nAre You Sure You Want To Cancle?", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                            Application.Exit();
                        } else {
                            goto Top2;
                        }
                    }
                    else {
                        goto Top;
                    }
                }
                else if (a == DialogResult.No) {
                    Application.Exit();
                }
            }
        } // Load
    } // main class
} // namespace
