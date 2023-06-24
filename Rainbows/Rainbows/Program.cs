using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainbows {
    class Program {
        static void Main(string[] args) {
            int type = 0;
            string[] Rb = new string[] {"R","a","i","n","b","o","w","s","!"," "};
            Random a = new Random();
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            while (true) {
                type = a.Next(1, 17);
                if (type == 16) {
                    type = a.Next(1, 16);
                    Switch(type);
                    foreach (string i in Rb) {
                        Console.Write(i);
                    }
                }
                else {
                    foreach (string i in Rb) {
                        type = a.Next(1, 16);
                        Switch(type);
                        Console.Write(i);
                    }
                }
            }
        }

        private static void Switch(int type) {
            switch (type) {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case 8:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case 9:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case 10:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 11:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 12:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case 13:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 14:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 15:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    break;
            }
        }
    }
}
