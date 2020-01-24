using System;

namespace Players
{
    internal class Player
    {
        public static readonly Random R = new Random();

        private string _name;
        private int _points;

        public Player(string name, int points)
        {
            _name = name;
            _points = points;
        }

        internal void Play(Player otherPlayer)
        {
            var score = R.Next(2) == 1 ? 1 : -1;
            _points += score;
            otherPlayer._points -= score;
            //Console.WriteLine(score);
        }

        internal void ShowNameAndPoints(Random random)
        {
            Console.WriteLine($"{_name}: {_points} points");
        }
    }
}