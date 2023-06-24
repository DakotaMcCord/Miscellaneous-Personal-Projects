using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS {
    class Program {
        static void Main(string[] args) {
            string PChoice = "Choice: ";
            string Choice;
            int W = 0;
            int L = 0;
            int T = 0;
            string Win = "You Won!!";
            string Lose = "You Lost.. :(";
            string Tie = "It's a Tie!!";
            string Enter = "<Press 'Enter' To Continue>";

            Console.WriteLine("Hello, This is Rock Paper Scissors.");
            Console.WriteLine("Made so You, Dear Player, can feel like you Have Friends!");
            Console.WriteLine("    Enjoy!! :)");
            Console.WriteLine();
            Console.WriteLine(Enter);
            Console.ReadLine();

            Console.Clear();

            Console.WriteLine("<To Throw, type 'Rock', 'Paper','Scissors' or 'R', 'P', 'S'.>");
            Console.WriteLine("  <Capitalization does Not Matter>");
            Console.WriteLine("<The Press 'Enter', Your Throw will be displayed after 'Choice:'.>");
            Console.WriteLine("  <The AI's will be displayed below that.>");
            Game:
            Console.WriteLine();
            Console.WriteLine("-Win--Tie--Lose-");
            Console.WriteLine("-" + W + "--" + T + "--" + L + "-");

            Random N1 = new Random();
            int A = N1.Next(1, 101);
            Random Num = new Random(A);
            int CChoice = Num.Next(1, 4);

            Console.Write(PChoice);
            Choice = Console.ReadLine();
            switch (CChoice) {
                case 1:
                    Console.WriteLine("Rock");
                    Console.WriteLine();
                    switch (Choice) {
                        case "Rock":
                            Rock:
                            T += 1;
                            Console.WriteLine(Tie);
                            break;
                        case "rock":
                            goto Rock;
                        case "R":
                            goto Rock;
                        case "r":
                            goto Rock;
                        case "Paper":
                            Paper:
                            W += 1;
                            Console.WriteLine(Win);
                            break;
                        case "paper":
                            goto Paper;
                        case "P":
                            goto Paper;
                        case "p":
                            goto Paper;
                        case "Scissors":
                            Scissors:
                            L += 1;
                            Console.WriteLine(Lose);
                            break;
                        case "scissors":
                            goto Scissors;
                        case "S":
                            goto Scissors;
                        case "s":
                            goto Scissors;
                        case "Tab":
                            Tab:
                            W += 1000;
                            Console.WriteLine("Err - You Win!!!");
                            break;
                        case "tab":
                            goto Tab;
                        case "T":
                            goto Tab;
                        case "t":
                            goto Tab;
                    }
                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine("Paper");
                    Console.WriteLine();
                    switch (Choice) {
                        case "Rock":
                            Rock:
                            L += 1;
                            Console.WriteLine(Lose);
                            break;
                        case "rock":
                            goto Rock;
                        case "R":
                            goto Rock;
                        case "r":
                            goto Rock;
                        case "Paper":
                            Paper:
                            T += 1;
                            Console.WriteLine(Tie);
                            break;
                        case "paper":
                            goto Paper;
                        case "P":
                            goto Paper;
                        case "p":
                            goto Paper;
                        case "Scissors":
                            Scissors:
                            W += 1;
                            Console.WriteLine(Win);
                            break;
                        case "scissors":
                            goto Scissors;
                        case "S":
                            goto Scissors;
                        case "s":
                            goto Scissors;
                        case "Tab":
                            Tab:
                            W += 1000;
                            Console.WriteLine("Err - You Win!!!");
                            break;
                        case "tab":
                            goto Tab;
                        case "T":
                            goto Tab;
                        case "t":
                            goto Tab;
                    }
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine("Scissors");
                    Console.WriteLine();
                    switch (Choice) {
                        case "Rock":
                            Rock:
                            W += 1;
                            Console.WriteLine(Win);
                            break;
                        case "rock":
                            goto Rock;
                        case "R":
                            goto Rock;
                        case "r":
                            goto Rock;
                        case "Paper":
                            Paper:
                            L += 1;
                            Console.WriteLine(Lose);
                            break;
                        case "paper":
                            goto Paper;
                        case "P":
                            goto Paper;
                        case "p":
                            goto Paper;
                        case "Scissors":
                            Scissors:
                            T += 1;
                            Console.WriteLine(Tie);
                            break;
                        case "scissors":
                            goto Scissors;
                        case "S":
                            goto Scissors;
                        case "s":
                            goto Scissors;
                        case "Tab":
                            Tab:
                            W += 1000;
                            Console.WriteLine("Err - You Win!!!");
                            break;
                        case "tab":
                            goto Tab;
                        case "T":
                            goto Tab;
                        case "t":
                            goto Tab;
                    }
                    Console.WriteLine();
                    break;
            }
            Console.Write(Enter);
            Console.ReadLine();
            Console.Clear();
            goto Game;

        }
    }
} 
