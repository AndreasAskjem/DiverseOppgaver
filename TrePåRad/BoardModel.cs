using System;

namespace TrePåRad
{
    public class BoardModel
    {
        public char[,] BoardState =
        {
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' }

        };

        internal void SetCross(string position)
        {
            if (position.Length != 2)
            {
                Console.WriteLine("Not valid input!");
                return;
            }
            var letter = position[0] - 'a';
            var digit = position[1] - '0'-1;
            if (letter > 2 || letter < 0 ||
                digit  > 2 || digit  < 0)
            {
                Console.WriteLine("Not valid input!");
                return;
            }

            if (IsTaken(letter, digit))
            {
                Console.WriteLine("This position is already taken!");
                Console.Write("Skriv inn hvor du vil sette kryss (f.eks. \"a2\"): ");
                position = Console.ReadLine();
                SetCross(position);
            }

            PlaceInput(letter, digit, 'x');
        }

        internal void SetRandomCircle()
        {
            int letter;
            int digit;
            do
            {
                letter = Random.Next(0, 3);
                digit = Random.Next(0, 3);
            } while(IsTaken(letter, digit));
            
            PlaceInput(letter, digit, 'o');
        }

        private void PlaceInput(int letter, int digit, char symbol)
        {
            BoardState[letter, digit] = symbol;
        }

        private bool IsTaken(int letter, int digit)
        {
            return BoardState[letter, digit] != ' ';
        }

        private static readonly Random Random = new Random();

        public char CheckIfWon()
        {
            var emptyFields = 0;
            var winner = ' ';
            var b = BoardState;
            if (b[0, 0] == b[0, 1] && b[0, 0] == b[0, 2] || //┌────
                b[0, 0] == b[1, 0] && b[0, 0] == b[2, 0])   //│
            {
                winner = b[0, 0];
            }
            else if (b[2, 2] == b[2, 1] && b[2, 2] == b[2, 0] || //    │
                     b[2, 2] == b[1, 2] && b[2, 2] == b[0, 2])   //────┘
            {
                winner = b[2, 2];
            }
            else if (b[1, 1] == b[1, 0] && b[1, 1] == b[1, 2] || // \ | /
                     b[1, 1] == b[0, 1] && b[1, 1] == b[2, 1] || // ─ ┼ ─
                     b[1, 1] == b[0, 0] && b[1, 1] == b[2, 2] || // / | \
                     b[1, 1] == b[0, 2] && b[1, 1] == b[2, 0])
            {
                winner = b[1, 1];
            }
            if(winner == ' ')
            {
                for (var i = 0; i < 3; i++)
                {
                    for (var j = 0; j < 3; j++)
                    {
                        if (b[i, j] == ' ')
                        {
                            emptyFields++;
                        }
                    }
                }
                if (emptyFields == 0) winner = 't';
            }

            return winner;
        }
    }
}