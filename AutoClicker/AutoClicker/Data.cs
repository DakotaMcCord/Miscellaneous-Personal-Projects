using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClicker {
    public class Data {
        public static bool 
            ChangeingHotkey = false, // see if hotkey is being Changed
            ClickByAmmount; // checks if clicking a number of times;

        public static int DefaultHotkey = 0x60; // Default Hotkey - Num0
        public static int Hotkey = 0x60; 
        public static string HotkeyText = "Numpad0";

    }
}
