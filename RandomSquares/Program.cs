using System;
using System.Threading;

namespace RandomSquares
{
    public class Program
    {
        private static int _width = 40;
        private static int _height = 20;

        static void Main(string[] args)
        {
            while (true)
            {
                var boxes = CreateBoxes();
                var i = 0;
                while (i < 40)
                {
                    Show(boxes);
                    foreach (var box in boxes)
                    {
                        box.Move();
                    }
                    Thread.Sleep(200);
                    i++;
                }
                Console.WriteLine("(press enter for new. ctrl+c=exit)");
                Console.ReadLine();
            }
        }

        private static Box[] CreateBoxes()
        {
            var random = new Random();
            var boxes = new Box[1];
            for (var i = 0; i < boxes.Length; i++)
            {
                boxes[i] = new Box(random, _width, _height);
            }
            return boxes;
        }

        private static void Show(Box[] boxes)
        {
            var screen = new VirtualScreen(_width,_height);
            foreach (var box in boxes)
            {
                screen.Add(box);
            }
            screen.Show();
        }

        /*
        private static void Test()
        {
            var cell = new VirtualScreenCell();
            cell.AddHorizontal();
            Console.WriteLine("Expected: ─");
            Console.WriteLine($"Actual: {cell.GetCharacter()}");

            cell = new VirtualScreenCell();
            cell.AddLowerLeftCorner();
            Console.WriteLine("Expected: └");
            Console.WriteLine($"Actual: {cell.GetCharacter()}");

            cell = new VirtualScreenCell();
            cell.AddUpperLeftCorner();
            Console.WriteLine("Expected: ┌");
            Console.WriteLine($"Actual: {cell.GetCharacter()}");

            cell = new VirtualScreenCell();
            cell.AddUpperLeftCorner();
            cell.AddUpperRightCorner();
            Console.WriteLine("Expected: ┬");
            Console.WriteLine($"Actual: {cell.GetCharacter()}");
        }
        */
    }
}
