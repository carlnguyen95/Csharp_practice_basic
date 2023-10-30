using System;
using System.Reflection;

namespace TicTacToe
{
    public class Program
    {
        //Properties
        static char[,] screen = new char[8, 8] {
            {' ', '\u2502', '0', '\u2502', '1', '\u2502', '2', '\u2502'},
            {'\u2500', '\u253C', '\u2500', '\u253C', '\u2500', '\u253C', '\u2500', '\u2524'},
            {'0', '\u2502', ' ', '\u2502', ' ', '\u2502', ' ', '\u2502'},
            {'\u2500', '\u253C', '\u2500', '\u253C', '\u2500', '\u253C', '\u2500', '\u2524'},
            {'1', '\u2502', ' ', '\u2502', ' ', '\u2502', ' ', '\u2502'},
            {'\u2500', '\u253C', '\u2500', '\u253C', '\u2500', '\u253C', '\u2500', '\u2524'},
            {'2', '\u2502', ' ', '\u2502', ' ', '\u2502', ' ', '\u2502'},
            {'\u2500', '\u2534', '\u2500', '\u2534', '\u2500', '\u2534', '\u2500', '\u2518'},
        };
        static int cursorX = 2;
        static int cursorY = 2;
        bool end = false;
        string[] players = { "Player1", "Player2" };

        //Constructor

        //Main method
        public static void Main(string[] args)
        {
            Program p = new Program();
            p.players = p.GetPlayerName();

            Console.Clear();

            p.Display();
            Console.SetCursorPosition(cursorY, cursorX);

            int i = 0;

            while (!p.end)
            {
                p.Play(p.players[i], i);
                p.CheckResult(p);
                i = (i == 1) ? 0 : ++i;
            }


        }

        public void Display()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write($"{screen[i, j]}");
                }
                Console.WriteLine();
            }
        }

        public string[] GetPlayerName()
        {
            Console.Write($"Name Player1: ");
            string player1 = Console.ReadLine();
            player1 = ((player1 != null) && (player1 != "")) ? player1.Trim() : "Player1";

            Console.Write($"Name Player2: ");
            string player2 = Console.ReadLine();
            player2 = ((player2 != null) && (player2 != "")) ? player2.Trim() : "Player2";
            string[] players = new string[] { player1, player2 };
            return players;
        }

        public void Play(string name, int player)
        {
            Console.SetCursorPosition(0, 9);
            Console.WriteLine($"It's {name}'s turn");
            Console.SetCursorPosition(cursorY, cursorX);
            char signature = (player == 0) ? 'X' : 'O';
            bool check = false;
            while (!check)
            {
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.RightArrow:
                        if (cursorY < 6)
                        {
                            cursorY += 2;
                        }
                        Console.SetCursorPosition(cursorY, cursorX);
                        break;

                    case ConsoleKey.LeftArrow:
                        if (cursorY > 2)
                        {
                            cursorY -= 2;
                        }
                        Console.SetCursorPosition(cursorY, cursorX);
                        break;

                    case ConsoleKey.DownArrow:
                        if (cursorX < 6)
                        {
                            cursorX += 2;
                        }
                        Console.SetCursorPosition(cursorY, cursorX);
                        break;

                    case ConsoleKey.UpArrow:
                        if (cursorX > 2)
                        {
                            cursorX -= 2;
                        }
                        Console.SetCursorPosition(cursorY, cursorX);
                        break;

                    //Check the move, update the array
                    case ConsoleKey.Enter:
                        Console.SetCursorPosition(cursorY, cursorX);
                        Console.WriteLine(signature);
                        screen[cursorX, cursorY] = signature;
                        Console.SetCursorPosition(cursorY, cursorX);
                        check = true;
                        break;

                    //Keep the value at the cursor clean
                    default:
                        Console.SetCursorPosition(cursorY, cursorX);
                        Console.WriteLine(" ");
                        Console.SetCursorPosition(cursorY, cursorX);
                        break;
                }
            }
        }

        public void CheckResult(Program p)
        {
            int winner = 0;
            for (int i = 0; i < 6; i = i + 2)
            {
                if (screen[i, 2] == 'X' && screen[i, 4] == 'X' && screen[i, 6] == 'X')
                {
                    winner = 1;
                    break;
                }
                else if (screen[i, 2] == 'O' && screen[i, 4] == 'O' && screen[i, 6] == 'O')
                {
                    winner = 2;
                    break;
                }
            }

            for (int i = 0; i < 6; i = i + 2)
            {
                if (screen[2, i] == 'X' && screen[4, i] == 'X' && screen[6, i] == 'X')
                {
                    winner = 1;
                    break;
                }
                else if (screen[2, i] == 'O' && screen[4, i] == 'O' && screen[6, i] == 'O')
                {
                    winner = 2;
                    break;
                }
            }

            if ((screen[2, 2] == 'X' && screen[4, 4] == 'X' && screen[6, 6] == 'X') ||
                (screen[2, 6] == 'X' && screen[4, 4] == 'X' && screen[6, 2] == 'X'))
            {
                winner = 1;
            }
            else if ((screen[2, 2] == 'O' && screen[4, 4] == 'O' && screen[6, 6] == 'O') ||
                (screen[2, 6] == 'O' && screen[4, 4] == 'O' && screen[6, 2] == 'O'))
            {
                winner = 2;
            }

            if (winner != 0)
            {
                Console.SetCursorPosition(10, 4);
                Console.WriteLine($"The winner is {p.players[winner - 1]}. Press Enter to exit");
                Console.CursorVisible = false;
                Console.ReadLine();
                Console.Clear();
                Console.CursorVisible = true;
                p.end = true;
            }
        }
    }
}