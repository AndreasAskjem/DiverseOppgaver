using System;

namespace RandomSquares
{
    public class Box
    {
        public int X { get; }
        public int Y { get; }
        public int StartY => Y;
        public int EndY => Y + Height;
        public int Width { get; }
        public int Height { get; }
        private int _minimumSize = 3;

        public Box(Random random, int maxX, int maxY)
        {
            Width = random.Next(_minimumSize, maxX);
            Height = random.Next(_minimumSize, maxY); //Subtract from 2nd values to add bottom/right border
            X = random.Next(0, maxX - Width);
            Y = random.Next(0, maxY - Height); // Add to 1st values to add top/left border
        }
    }
}
