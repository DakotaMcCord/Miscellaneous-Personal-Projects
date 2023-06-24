using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rainbows__Form_ {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            timer1.Start();
        }
        Random RNG = new Random();
        private void timer1_Tick(object sender, EventArgs e) {
            label1.ForeColor = Color.FromArgb(RNG.Next(0, 256), RNG.Next(0, 256), RNG.Next(0, 256), RNG.Next(0, 256));
        }
    }
}
