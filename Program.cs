using System;

namespace EscapeFromLabyrinth
{
    class Program
    {
        public static void Main(string[] args)
        {
            string welcomeMessage = "Welcome to “Labirinth” game. Please try to escape. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.";
            Labyrinth game = new Labyrinth();
            game.InitializeLabyrinth();
            Console.WriteLine(welcomeMessage);
            game.ShowLabyrinth();
            game.Move();
        }
    }
}
