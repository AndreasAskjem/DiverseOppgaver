using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using Point = System.Drawing.Point;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;


namespace SquareGame
{
    public class Player
    {
        private int size;
        public int Size
        {
            get { return Application.Current.Resources[PlayerRectangle]; }
            set { size = value; }
        }

        public object Pos;

        private int posX;

        

        public double VerticalSpeed { get; set; }
        public double HorizontalSpeed { get; set; }

        //public int MaxHeight = Display.

        public UIElement UIElement { get; set; }
        public Player()
        {
            Size = 50;
            VerticalSpeed = 0;
            HorizontalSpeed = 0;
        }

    }
}