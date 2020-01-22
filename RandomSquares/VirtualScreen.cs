using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void Add(Box box) { }
        public void Show() { }
    }
}
