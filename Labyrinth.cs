using System;

namespace EscapeFromLabyrinth
{
    public class Labyrinth
    {
        //Fields
        private const int GameFieldSize = 7;
        private int[,] gameField;
        private string enterMove = "Enter your move (L=left, R=right, U=up, D=down):";
        private string welcome = "Welcome to “Labirinth” game. Please try to escape. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.";
        private int m = 3;
        private int n = 3;
        private bool playGame = true;
        private string[] topScores = new string[5];

        //Constructors
        public Labyrinth()
        {
            this.gameField = new int[GameFieldSize, GameFieldSize];
        }

        //Properties
        //...

        //Functions
        public void InitializeLabyrinth()
        {
            Random random = new Random();
            for (int row = 0; row < GameFieldSize; row++)
            {
                for (int col = 0; col < GameFieldSize; col++)
                {
                    gameField[row, col] = random.Next(2);
                }
            }
            gameField[3, 3] = 2;
        }

        public void ShowLabyrinth()
        {
            for (int i = 0; i < GameFieldSize; i++)
            {
                for (int j = 0; j < GameFieldSize; j++)
                {
                    if (gameField[i, j] == 0)
                    {
                        Console.Write("- ");
                    }
                    else if (gameField[i, j] == 2)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("X ");
                    }
                }
                Console.WriteLine();
            }
        }

        public void ShowTopScores()
        {
            for (int i = 0; i < topScores.Length; i++)
            {
                if (topScores[i] != null)
                {
                    Console.WriteLine(i + 1 + " - " + topScores[i]);
                }
            }

            if (topScores[0] == null && topScores[1] == null && topScores[2] == null && topScores[3] == null && topScores[4] == null)
            {
                Console.WriteLine("The scoreboard is empty.");
            }
        }

        public void Move()
        {
            int steps = 0;

            while (playGame == true)
            {
                Console.Write(enterMove);
                string input = Console.ReadLine();

                if (input.Length > 1 || input.Length == 0)
                {
                    switch (input)
                    {
                        case "exit":
                            Console.WriteLine("Good Bye!");
                            playGame = false;
                            break;
                        case "restart":
                            InitializeLabyrinth();
                            ShowLabyrinth();
                            playGame = true;
                            m = 3;
                            n = 3;
                            Move();
                            break;
                        case "top":
                            ShowTopScores();
                            playGame = true;
                            break;
                        default:
                            Console.WriteLine("Invalid command");
                            playGame = true;
                            break;
                    }
                }
                else
                {
                    switch (input)
                    {
                        case "L":
                            if (gameField[m, n - 1] == 0)
                            {
                                gameField[m, n - 1] = 2;
                                gameField[m, n] = 0;
                                n -= 1;
                                steps++;
                                if (n - 1 < 0)
                                {
                                    Console.WriteLine("Congratulations! You escaped in {0} moves.", steps);
                                    InitializeLabyrinth();
                                    Console.WriteLine("\n" + welcome);
                                    Console.WriteLine(enterMove);
                                    ShowLabyrinth();
                                    m = 3;
                                    n = 3;
                                    Move();
                                }
                                else
                                {
                                    ShowLabyrinth();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid move!");
                            }
                            break;
                        case "R":
                            if (gameField[m, n + 1] == 0)
                            {
                                gameField[m, n + 1] = 2;
                                gameField[m, n] = 0;
                                n += 1;
                                steps++;
                                if (n + 1 > 6)
                                {
                                    Console.WriteLine("Congratulations! You escaped in {0} moves.", steps);
                                    InitializeLabyrinth();

                                    Console.WriteLine("\n" + welcome);
                                    Console.WriteLine(enterMove);
                                    ShowLabyrinth();
                                    m = 3;
                                    n = 3;
                                    Move();
                                }
                                else
                                {
                                    ShowLabyrinth();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid move!");
                            }
                            break;
                        case "U":
                            if (gameField[m - 1, n] == 0)
                            {
                                gameField[m - 1, n] = 2;
                                gameField[m, n] = 0;
                                m -= 1;

                                steps++;
                                if (m - 1 < 0)
                                {
                                    Console.WriteLine("Congratulations! You escaped in {0} moves.", steps);
                                    InitializeLabyrinth();
                                    Console.WriteLine("\n" + welcome);
                                    Console.WriteLine(enterMove);
                                    ShowLabyrinth();
                                    m = 3;
                                    n = 3;
                                    Move();
                                }
                                else
                                {
                                    ShowLabyrinth();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid move!");
                            }
                            break;
                        case "D":
                            if (gameField[m + 1, n] == 0)
                            {
                                gameField[m + 1, n] = 2;
                                gameField[m, n] = 0;
                                m += 1;
                                steps++;
                                if (m + 1 > 6)
                                {
                                    Console.WriteLine("Congratulations! You escaped in {0} moves.", steps);
                                    InitializeLabyrinth();
                                    Console.WriteLine("\n" + welcome);
                                    Console.WriteLine(enterMove);
                                    ShowLabyrinth();
                                    m = 3;
                                    n = 3;
                                    Move();
                                }
                                else
                                {
                                    ShowLabyrinth();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid move!");
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid move");
                            break;
                    }
                }
            }
        }
    }
}