using System;

namespace RandomSquares
{
    public class VirtualScreen
    {
        private VirtualScreenRow[] _rows;

        public VirtualScreen(int width, int height)
        {
            _rows = new VirtualScreenRow[height];
            for (var i = 0; i < _rows.Length; i++)
            {
                _rows[i] = new VirtualScreenRow(width);
            }
        }

        public void Add(Box box)
        {
            //box.
            foreach (var row in _rows)
            {
                for (var i = 0; i < box.Height - 2; i++)
                {
                    row.AddBoxTopRow(box.X, box.Width); // Need IFs
                    row.AddBoxMiddleRow(box.X, box.Width);
                    row.AddBoxBottomRow(box.X, box.Width);
                }
            }
        }

        public void Show()
        {
            foreach (var row in _rows)
            {
                row.Show();
            }
        }
    }
}
