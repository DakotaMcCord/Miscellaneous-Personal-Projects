using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoClicker {
    public partial class HotKeyChange : Form {
        public HotKeyChange() {
            InitializeComponent();
        }
        private void HotKeyChange_Load(object sender, EventArgs e) {
            this.CenterToParent();
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            EstablishTheD();

            ResetBTNText();
        }
        
        private void BTN_ChangeHotKey_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Are you sure you want to change your Hotkey?", "Confirm Hotkey Change",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                // Change Key
                Data.ChangeingHotkey = true;
            }
        }
        private void BTN_ChangeHotKey_KeyDown(object sender, KeyEventArgs e) {
            if (Data.ChangeingHotkey) {
                Keys HKey = e.KeyCode;
                Data.Hotkey = SwitcktoKeyCode(HKey);
                Keys K = SwitcktoCodeToKey(Data.Hotkey.ToString());
                Data.HotkeyText = K.ToString();
                
                ResetBTNText();
                Data.ChangeingHotkey = false;
            }
        }
        private void BTN_Accept_Click(object sender, EventArgs e) {

        }
        private void BTN_Close_Click(object sender, EventArgs e) {
            this.Close();
        }
        public void ResetBTNText() {
            BTN_ChangeHotKey.Text =
                $"Change Hotkey{Environment.NewLine}" +
                $"Current Hotkey: {Data.HotkeyText}";
        }

        public int SwitcktoKeyCode(Keys KeyToSwitch) {
            string _Value = Data.DefaultHotkey.ToString();
            foreach (Keys K in VKeys.Keys) {
                if (K == KeyToSwitch) {

                    _Value = VKeys[K];
                }
            }
            return Convert.ToInt32(_Value, 16);
        }
        public Keys SwitcktoCodeToKey(string CodeToSwitch) {
            List<Keys> key = VKeys.Keys.ToList();
            List<string> code = VKeys.Values.ToList();

            Keys _Value = Keys.NumPad0;
            foreach (string C in VKeys.Values) {
                if (Convert.ToInt32(C, 16) == int.Parse(CodeToSwitch)) {
                    _Value = key[code.IndexOf(C)];
                    break;
                }
            }
            return _Value;
        }

        Dictionary<Keys, string> VKeys = new Dictionary<Keys, string>();
        public void EstablishTheD() {
            VKeys.Add(Keys.A, "0x41");
            VKeys.Add(Keys.B, "0x42");
            VKeys.Add(Keys.C, "0x43");
            VKeys.Add(Keys.D, "0x44");
            VKeys.Add(Keys.E, "0x45");
            VKeys.Add(Keys.F, "0x46");
            VKeys.Add(Keys.G, "0x47");
            VKeys.Add(Keys.H, "0x48");
            VKeys.Add(Keys.I, "0x49");
            VKeys.Add(Keys.J, "0x4A");
            VKeys.Add(Keys.K, "0x4B");
            VKeys.Add(Keys.L, "0x4C");
            VKeys.Add(Keys.M, "0x4D");
            VKeys.Add(Keys.N, "0x4E");
            VKeys.Add(Keys.O, "0x4F");
            VKeys.Add(Keys.P, "0x50");
            VKeys.Add(Keys.Q, "0x51");
            VKeys.Add(Keys.R, "0x52");
            VKeys.Add(Keys.S, "0x53");
            VKeys.Add(Keys.T, "0x54");
            VKeys.Add(Keys.U, "0x55");
            VKeys.Add(Keys.V, "0x56");
            VKeys.Add(Keys.W, "0x57");
            VKeys.Add(Keys.X, "0x58");
            VKeys.Add(Keys.Y, "0x59");
            VKeys.Add(Keys.Z, "0x5A");
            
            VKeys.Add(Keys.D0, "0x30");
            VKeys.Add(Keys.D1, "0x31");
            VKeys.Add(Keys.D2, "0x32");
            VKeys.Add(Keys.D3, "0x33");
            VKeys.Add(Keys.D4, "0x34");
            VKeys.Add(Keys.D5, "0x35");
            VKeys.Add(Keys.D6, "0x36");
            VKeys.Add(Keys.D7, "0x37");
            VKeys.Add(Keys.D8, "0x38");
            VKeys.Add(Keys.D9, "0x39");

            VKeys.Add(Keys.NumPad0, "0x60");
            VKeys.Add(Keys.NumPad1, "0x61");
            VKeys.Add(Keys.NumPad2, "0x62");
            VKeys.Add(Keys.NumPad3, "0x63");
            VKeys.Add(Keys.NumPad4, "0x64");
            VKeys.Add(Keys.NumPad5, "0x65");
            VKeys.Add(Keys.NumPad6, "0x66");
            VKeys.Add(Keys.NumPad7, "0x67");
            VKeys.Add(Keys.NumPad8, "0x68");
            VKeys.Add(Keys.NumPad9, "0x69");

            VKeys.Add(Keys.OemPeriod, "0xBE");
            // ??
        }
    }
}
