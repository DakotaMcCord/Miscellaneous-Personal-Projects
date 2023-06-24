using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake_Console_ {
    class Program {
        public static string
            Wall = "%", //"🔷",
            Space = " ", //"🔅",

            Head = "@", //"🔲",
            Body = "#", //"◼",

            Food = "&"; //"🍖";
        public static int
            Height = 15,
            Width = 20,

            SPosX = 5,
            SPosY = 5,

            FPosX,
            FPosY,

            Length = 0,
            INC = 5,
            
            WaitTime = 112;

        public enum Directions { Up, Left, Down, Right }
        public static Directions Direction;

        public static List<Snake> Snakes = new List<Snake>();

        static void Main(string[] args) {
            Console.Title = "Snake(Console)";
            Console.WindowHeight = 20;
            Console.WindowWidth = 30;
            Console.ForegroundColor = ConsoleColor.Gray;

        Top:
            Snakes.Clear();
            SPosX = 10;
            SPosY = 10;
            Length = 0;
            
            GenerateFood();
            bool a = true;
            while (a == true) {
                Update();
                Draw();
                foreach (Snake snake in Snakes) {
                    if (snake.X == SPosX && snake.Y == SPosY) {
                        a = false;
                    }
                }
                if  (SPosX == 0 || SPosX == Width || SPosY == 0 || SPosY == Height) {
                    a = false;
                }
                if (a == false) {
                    Console.WriteLine("Game Over");
                    break;
                }
                Thread.Sleep(WaitTime);
            }

            Console.ReadLine();
            goto Top;
        }
        public static void Update() {
            int LX = SPosX, LY = SPosY;

            if (Console.KeyAvailable) {
                ConsoleKey Key = Console.ReadKey().Key;
                if (Key == ConsoleKey.UpArrow) {
                    Direction = Directions.Up;
                }
                else if (Key == ConsoleKey.LeftArrow) {
                    Direction = Directions.Left;
                }
                else if (Key == ConsoleKey.DownArrow) {
                    Direction = Directions.Down;
                }
                else if (Key == ConsoleKey.RightArrow) {
                    Direction = Directions.Right;
                }
            }

            switch (Direction) {
                case Directions.Up:
                    if (SPosY != 0) { SPosY--; }
                    break;
                case Directions.Left:
                    if (SPosX != 0) { SPosX--; }
                    break;
                case Directions.Down:
                    if (SPosY != Height) { SPosY++; }
                    break;
                case Directions.Right:
                    if (SPosX != Width) { SPosX++; }
                    break;
                default:
                    break;
            }

            if (SPosX == FPosX && SPosY == FPosY) {
                Console.Beep(533, 95);
                for (int i = 0; i < INC; i++) {
                    Snakes.Insert(0, new Snake(LX, LY));
                    Length++;
                }
                GenerateFood();
            }
            else {
                Snakes.Insert(0, new Snake(LX, LY));
                Snakes.RemoveAt(Snakes.Count - 1);
            }
        }
        public static void Draw() {
            Console.Clear();
            for (int Y = 0; Y < (Height + 1); Y++) {
                for (int X = 0; X < (Width + 1); X++) {
                    bool Printed = false;
                    foreach (Snake snake in Snakes) {
                        if ((snake.X == X && snake.Y == Y) && (snake.X != SPosX || snake.Y != SPosY)) {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write(Body);
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Printed = true;
                            break;
                        }
                    }
                    if (Printed != true) {
                        if (X == SPosX && Y == SPosY) {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(Head);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else if (X == FPosX && Y == FPosY) {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(Food);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else if ((Y == 0 || Y == Height) || (X == 0 || X == Width)) {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(Wall);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else {
                            Console.Write(Space);
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine(Length);
        }
        public static void GenerateFood() {
            Random RNG = new Random();
            Top:
            FPosX = RNG.Next(1, Width);
            FPosY = RNG.Next(1, Height);
            foreach (Snake snake in Snakes) {
                if ((FPosX == snake.X && FPosY == snake.Y) || (FPosX == SPosX && FPosY == SPosY)) {
                    goto Top;
                }
            }
        }
    }
    class Snake {

        public int X, Y;

        public Snake(int x, int y) {
            X = x;
            Y = y;
        }
    }
}
