using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Timers;

namespace AutoClicker {
    public partial class UIWindow : Form {

        #region Mouse
        //Mouse VVVV
        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
      
        public const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        public const int MOUSEEVENTF_LEFTUP = 0x0004;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        public const int MOUSEEVENTF_RIGHTUP = 0x0010;
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        public const int MOUSEEVENTF_MIDDLEUP = 0x0040;

        public enum ClickType { 
            LClick = 0, LHold = 1,
            RClick = 2, RHold = 3, 
            MClick = 4, MHold = 5};
        public ClickType CurentClickType;

        private void HoldClickLeftMouseButton() {
            //Send a left click down followed by a left click up to simulate a  
            //full left click 
            Thread.Sleep(100);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
        }
        private void ClickLeftMouseButton() {
            //Send a left click down followed by a left click up to simulate a  
            //full left click 
            Thread.Sleep(100);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            Thread.Sleep(100);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
        private void ClickRightMouseButton() {
            //Send a right click down followed by a right click up to simulate a  
            //full right click 
            Thread.Sleep(100);
            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
            Thread.Sleep(100);
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
        }
        #endregion
        #region Hotkey
        // Keyboard Shortcut VVVV
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public const int MOD_ALT = 0x0001;
        public const int MOD_CONTROL = 0x0002;
        public const int MOD_SHIFT = 0x0004;
        public const int MOD_NOREPEAT = 0x4000;
        public const int WM_HOTKEY = 0x0312;


        #endregion
        bool
            Registerd,  // Used for Debug
            ClickerActive; // Checks if Clicking
            

        public const string 
            BTN_StartStop_Active = "Start/Stop: (Active)",
            BTN_StartStop_Inactive = "Start/Stop: (Inactive)";

        

        public UIWindow() {
            InitializeComponent();

        }
        private void UIWindo_Load(object sender, EventArgs e) {
            ClickerActive = false;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            SLDR_ClickType.Value = 0;
            CurentClickType = (ClickType)SLDR_ClickType.Value;
            
            BTN_StartStop.Text = BTN_StartStop_Inactive;

            Registerd = RegisterHotKey(this.Handle, 1, 0X0000, Data.Hotkey);
            //if (Registerd) {
            //    this.Text = "t";
            //}
            //else {
            //    this.Text = "f";
            //}
            SLDR_RepeatType.Value = 1;
            ToggleRepeatType();


        } // Activates on Startup
        private void UIWindow_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                e.SuppressKeyPress = true;
                e.Handled = true;
                Application.Exit();
            }
        } // Close Window
        
        bool JustClicked = false;
        System.Timers.Timer CDelay;
        private void BTN_StartStop_Click(object sender, EventArgs e) {
            if (!JustClicked) {
                JustClicked = true;
                CDelay = new System.Timers.Timer(3000);
                CDelay.AutoReset = false;
                CDelay.Elapsed += ClickDelay;
                CDelay.Start();

                SetActivationStatus();
            }
        } // Start/Stop
        public void ClickDelay(object source, ElapsedEventArgs e) {
            JustClicked = false;
            
            // do stuff
        } // Delay Start/Stop Button
        
        System.Timers.Timer ticker;
        private void BTN_HotkeyEdit_Click(object sender, EventArgs e) {
            if (!ClickerActive) {
                HotKeyChange HKC = new HotKeyChange();
                UnregisterHotKey(this.Handle, 1);
                HKC.ShowDialog(this);
                Registerd = RegisterHotKey(this.Handle, 1, 0x0000, Data.Hotkey);
            }
        } // Change HotKey
        private void SLDR_ClickType_Scroll(object sender, EventArgs e) {
            CurentClickType = (ClickType)SLDR_ClickType.Value;
        } // Slider Adjust Click Type
        private void UIWindow_FormClosing(object sender, FormClosingEventArgs e) {
            ResetButtons();
        }
        protected override void WndProc(ref Message m) {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == 1) {
                SetActivationStatus();
            }
            base.WndProc(ref m);
        }

        public bool InitialTrigger;
        public int _Interval;
        public void SetActivationStatus() {
            if (!Data.ChangeingHotkey) {
                if (ClickerActive) {
                    ClickerActive = false;
                    BTN_StartStop.Text = BTN_StartStop_Inactive;

                    ticker.Stop();

                    ResetButtons();
                }
                else {
                    ClickerActive = true;
                    InitialTrigger = true;
                    BTN_StartStop.Text = BTN_StartStop_Active;

                    if (NUD_DelayMSeconds.Value < 10) {
                        NUD_DelayMSeconds.Value = 10;
                    }

                    ClicksLeft = (int)NUD_TimesAmount.Value;

                    int Interval,
                        H = (int)NUD_DelayHours.Value * (3600000),
                        M = (int)NUD_DelayMinute.Value * (60000),
                        S = (int)NUD_DelaySeconds.Value * (1000),
                        MS = (int)NUD_DelayMSeconds.Value * (1);
                    Interval = H + M + S + MS;
                    _Interval = Interval;

                    ticker = new System.Timers.Timer(50);
                    ticker.Elapsed += OnTimedEvent;
                    ticker.Start();
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e) {
            ToggleRepeatType();
        } // Sets Repeat Type;
        public void ToggleRepeatType() {
            if (SLDR_RepeatType.Value == 1) {
                Data.ClickByAmmount = false;
            }
            else if (SLDR_RepeatType.Value == 0) {
                Data.ClickByAmmount = true;
            }
        }

        int ClicksLeft;
        public void OnTimedEvent(object source, ElapsedEventArgs e) {
            if (InitialTrigger) {
                ticker.Interval = _Interval;
            }
            if (Data.ClickByAmmount) {
                Top:
                if (ClicksLeft <= 0) {
                    ClickerActive = false;
                    ticker.Stop();
                    ResetButtons();
                    if (MessageBox.Show(
                        $"Task Completed.{Environment.NewLine}" +
                        $"The Clicker Will Now Close", "Task Completed.", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Exclamation, 
                        MessageBoxDefaultButton.Button1) == DialogResult.OK) {
                        Application.Exit();
                    }
                }
                else {
                    ClicksLeft--;
                    GetClickType();
                    if (ClicksLeft == 0) { goto Top; }
                }
            }
            else {
                GetClickType();
            }
        }
        public void GetClickType() {
            switch (CurentClickType) {
                case ClickType.LClick:
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    Thread.Sleep(100);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                    Thread.Sleep(100);
                    break;
                case ClickType.LHold:
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    Thread.Sleep(100);
                    break;
                case ClickType.RClick:
                    mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                    Thread.Sleep(100);
                    mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
                    Thread.Sleep(100);
                    break;
                case ClickType.RHold:
                    mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                    Thread.Sleep(100);
                    break;
                case ClickType.MClick:
                    mouse_event(MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0);
                    Thread.Sleep(100);
                    mouse_event(MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0);
                    Thread.Sleep(100);
                    break;
                case ClickType.MHold:
                    mouse_event(MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0);
                    Thread.Sleep(100);
                    break;
            }
        }
        public void ResetButtons() {
            if (ticker != null && ticker.Enabled) {
                ticker.Stop();
            }
            if (CDelay != null && CDelay.Enabled) {
                ticker.Stop();
            }
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            Thread.Sleep(100);
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
            Thread.Sleep(100);
            mouse_event(MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0);
            Thread.Sleep(100);
        }
    }
}
