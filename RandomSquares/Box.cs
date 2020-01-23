using System;

namespace RandomSquares
{
    public class Box
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int StartY => Y;
        public int EndY => Y + Height;
        public int Width { get; }
        public int Height { get; }
        private readonly int _minimumSize = 3;

        private readonly int _speedX;
        private readonly int _speedY;

        public Box(Random random, int maxX, int maxY)
        {
            Width = random.Next(_minimumSize, maxX);
            Height = random.Next(_minimumSize, maxY); //Subtract from 2nd values to add bottom/right border
            X = random.Next(0, maxX - Width);
            Y = random.Next(0, maxY - Height); // Add to 1st values to add top/left border

            _speedX = random.Next(-1, 2)*2;

            if (_speedX != 0)
            {
                _speedY = random.Next(-1, 2);
            }
            else
            {
                _speedY = random.Next(0, 2) == 0 ? -1 : 1;
            }
        }

        public void Move()
        {
            X += _speedX;
            Y += _speedY;
        }
    }
}
