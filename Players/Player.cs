using System;

namespace Players
{
    internal class Player
    {
        private string _name;
        private int _points;

        public Player(string name, int points)
        {
            _name = name;
            _points = points;
        }

        internal void Play(Player otherPlayer)
        {
            throw new NotImplementedException();
        }
    }
}