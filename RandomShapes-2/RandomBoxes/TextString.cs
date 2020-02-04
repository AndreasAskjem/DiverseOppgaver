using System;

namespace RandomBoxes
{
    internal class TextString : Shape
    {
        private string _txt;

        public TextString(int x, int y,string txt, Random random)
        {
            X = x;
            Y = y;
            _txt = txt;
        }

        public override string GetCharacter(int row, int col)
        {
            if (row != Y || col < X || col >= X + _txt.Length) return null;
            var index = col - X;
            return _txt[index].ToString();
        }
    }
}