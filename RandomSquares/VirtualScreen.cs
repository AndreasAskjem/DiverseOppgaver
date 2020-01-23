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
            
            for (var i = 0; i < _rows.Length; i++)
            {
                var row = _rows[i];
                if (i == box.StartY)
                {
                    row.AddBoxTopRow(box.X, box.Width);
                }
                else if (i == box.EndY)
                {
                    row.AddBoxBottomRow(box.X, box.Width);
                }
                else if (i > box.StartY && i < box.EndY)
                {
                    row.AddBoxMiddleRow(box.X, box.Width);
                }
            }
        }

        public void Show()
        {
            var screen = string.Empty;
            foreach (var row in _rows)
            {
                screen += row.Show();
                screen += "\n";
            }

            Console.WriteLine(screen);
        }
    }
}
