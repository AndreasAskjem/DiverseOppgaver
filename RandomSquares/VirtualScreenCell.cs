namespace RandomSquares
{
    public class VirtualScreenCell
    {
        public VirtualScreenCell()
        {

        }
        public bool Up { get; private set; }
        public bool Down { get; private set; }
        public bool Left { get; private set; }
        public bool Right { get; private set; }

        public void AddHorizontal()
        {
            Left = true;
            Right = true;
        }

        public void AddVertical()
        {
            Up = true;
            Down = true;
        }

        public void AddLowerLeftCorner()
        {
            Right = true;
            Up = true;
        }

        public void AddUpperLeftCorner()
        {
            Right = true;
            Down = true;
        }

        public void AddUpperRightCorner()
        {
            Left = true;
            Down = true;
        }

        public void AddLowerRightCorner()
        {
            Left = true;
            Up = true;
        }

        public char GetCharacter()
        {
            if (Up && Down && !Left && !Right)
            {
                return '│';
            }
            if (Up && Down && Left && !Right)
            {
                return '┤';
            }
            if (Up && Down && !Left && Right)
            {
                return '├';
            }
            if (Up && Down && !Left && !Right)
            {
                return '│';
            }
            if (!Up && !Down && Left && Right)
            {
                return '─';
            }
            if (Up && !Down && Left && Right)
            {
                return '┴';
            }
            if (!Up && Down && Left && Right)
            {
                return '┬';
            }
            if (Up && !Down && Left && !Right)
            {
                return '┘';
            }
            if (Up && !Down && !Left && Right)
            {
                return '└';
            }
            if (!Up && Down && Left && !Right)
            {
                return '┐';
            }
            if (!Up && Down && !Left && Right)
            {
                return '┌';
            }
            if (Up && Down && Left && Right)
            {
                return '┼';
            }

            if (!(Up || Down || Left || Right))
            {
                return ' ';
            }

            return '#';
        }
    }
}