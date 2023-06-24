using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Runner_Console_ {
    class Program {
        public static readonly Char Player = '@', Space = ' ', Wall = '=';
        public static List<Block> Blocks = new List<Block>();
        public static int Height = 10, Width = 50,
            PPosX = 5, PPosY = 6,
            WaitTime = 100, Score = 0;
        public static bool Loop = true;
        static void Main(string[] args) {
            Console.Title = "Runner(Console)";
            Console.WindowHeight = 15;
            Console.WindowWidth = 50;
            Top:
            Loop = true;
            Score = 0;
            while (Loop) {
                Update();
                Draw();
                Thread.Sleep(WaitTime);
            }
            Console.ReadLine();
            goto Top;
        }

        private static void Update() {
            if (Console.KeyAvailable) {
                ConsoleKey Key = Console.ReadKey().Key;
                if (Key == ConsoleKey.UpArrow && PPosY != 1 && PPosY == Height-1) {
                    PPosY -= 5;
                }
                else if (Key == ConsoleKey.RightArrow && PPosX < Width-1) {
                    PPosX += 1;
                }
                else if (Key == ConsoleKey.DownArrow && PPosY != Height - 1) {
                    PPosY += 1;
                }
                else if (Key == ConsoleKey.LeftArrow && PPosX > 0) {
                    PPosX -= 1;
                }


            }
            if (RNG.NumberBetween(0, 50) <= 12) {
                Blocks.Add(new Block(RNG.NumberBetween(1, 3), Width + 1));
            }
            if (PPosY < Height - 1) {
                PPosY += 1;
            }
            for (int i = 0; i < Blocks.Count; i++) {
                Blocks[i].XPos -= 1;
                if (PPosX == Blocks[i].XPos && PPosY >= Height - Blocks[i].Height) {
                    Loop = false;
                }
                if (Blocks[i].XPos < 0) {
                    Blocks.Remove(Blocks[i]);
                    i--;
                }
            }

            Score += 1;
        }
        private static void Draw() {
            Console.Clear();
            for (int Y = 0; Y < Height+1; Y++) {
                for (int X = 0; X < Width+1; X++) {
                    bool skip = false;
                    foreach (Block block in Blocks) {
                        if ((block.XPos == X && Height - block.Height <= Y) && (Y != 0 && Y != Height)) {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write(Wall);
                            Console.ForegroundColor = ConsoleColor.Gray;
                            skip = true;
                        }
                    }
                    if (X == PPosX && Y == PPosY && skip == false) {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(Player);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (Y == 0 || Y == Height) {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write(Wall);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (skip == false) {
                        Console.Write(Space);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine(Score);
            if (Loop == false) {
                Console.WriteLine("Game Over");
            }
        }
    }
    public class Block {
        public int Height, XPos;
        public Block(int height, int xPos) {
            Height = height;
            XPos = xPos;
        }
    }

    public class RNG {
        public static Random random = new Random();
        public static int NumberBetween(int Min, int Max) {
            return random.Next(Min, Max+1);
        }
    }
}
