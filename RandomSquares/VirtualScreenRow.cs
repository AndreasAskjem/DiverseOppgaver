using System;

namespace RandomSquares
{
    public class VirtualScreenRow
    {
        private VirtualScreenCell[] _cells;

        public VirtualScreenRow(int screenWidth)
        {
            _cells = new VirtualScreenCell[screenWidth];
            for (var i = 0; i < _cells.Length; i++)
            {
                _cells[i] = new VirtualScreenCell();
            }
        }


        public void AddBoxTopRow(int boxX, int boxWidth)
        {
            var screenWidth = _cells.Length;

            for (var i = 0; i < screenWidth; i++)
            {
                if (i == boxX)
                {
                    _cells[i].AddUpperLeftCorner();
                }
                else if(i == boxX +boxWidth)
                {
                    _cells[i].AddUpperRightCorner();
                }
                else if(i > boxX && i < boxX + boxWidth)
                {
                    _cells[i].AddHorizontal();
                }
            }
        }

        public void AddBoxBottomRow(int boxX, int boxWidth)
        {
            var screenWidth = _cells.Length;

            for (var i = 0; i < screenWidth; i++)
            {
                if (i == boxX)
                {
                    _cells[i].AddLowerLeftCorner();
                }
                else if (i == boxX + boxWidth)
                {
                    _cells[i].AddLowerRightCorner();
                }
                else if (i > boxX && i < boxX + boxWidth)
                {
                    _cells[i].AddHorizontal();
                }
            }
        }

        public void AddBoxMiddleRow(int boxX, int boxWidth)
        {
            var screenWidth = _cells.Length;

            for (var i = 0; i < screenWidth; i++)
            {
                if (i == boxX || i == boxX + boxWidth)
                {
                    _cells[i].AddVertical();
                }
            }
        }

        public void Show()
        {
            foreach (var cell in _cells)
            {
                Console.Write(cell.GetCharacter());
            }

            Console.WriteLine();
        }
    }
}