using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace TrePåRad
{
    class Program
    {
        static void Main(string[] args)
        {
            StartNewGame();
        }

        private static void StartNewGame()
        {
            var game = new BoardModel();
            Show(game);
            var winner = ' ';
            while (winner == ' ')
            {
                Console.Write("Skriv inn hvor du vil sette kryss (f.eks. \"a2\"): ");
                var position = Console.ReadLine();
                game.SetCross(position);
                Show(game);
                winner = game.CheckIfWon();
                if(winner != ' ') continue;

                Thread.Sleep(1000);
                game.SetRandomCircle();
                Show(game);
                winner = game.CheckIfWon();
            }

            if (winner == 'x')
            {
                Console.Write("You won! Play again? (y/n)");
                var answer = Console.ReadLine();
                if(answer=="y") StartNewGame();
            }
            else if (winner == 'o')
            {
                Console.Write("You lost! Play again? (y/n)");
                var answer = Console.ReadLine();
                if (answer == "y") StartNewGame();
            }
            else if (winner == 't')
            {
                Console.Write("It's a tie! Play again? (y/n)");
                var answer = Console.ReadLine();
                if (answer == "y") StartNewGame();
            }
        }

        private static void Show(BoardModel game)
        {
            for (var i = 0; i < 25; i++)
            {
                Console.WriteLine(); // Makes the board appear at the bottom every time.
            }
            string[] board = {
                 "  a b c",
                 " ┌─────┐",
                $"1│{game.BoardState[0,0]} {game.BoardState[1,0]} {game.BoardState[2,0]}│",
                $"2│{game.BoardState[0,1]} {game.BoardState[1,1]} {game.BoardState[2,1]}│",
                $"3│{game.BoardState[0,2]} {game.BoardState[1,2]} {game.BoardState[2,2]}│",
                 " └─────┘"
            };
            foreach (var line in board)
            {
                Console.WriteLine(line);
            }
        }
    }
}
