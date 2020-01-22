using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
                Show(boxes);
                Console.WriteLine("(press enter for new. ctrl+c=exit)");
                Console.ReadLine();
            }
        }

        private static Box[] CreateBoxes()
        {
            var random = new Random();
            var boxes = new Box[3];
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
    }
    /*
    class Program
    {
        static void Main(string[] args)
        {
            var cell = new VirtualScreenCell();
            cell.AddLowerLeftCorner();
            //cell.AddVertical();

            var row = new VirtualScreenRow(10);

            //var box = new Box();
            
           // row.AddBoxTopRow(1, 10);
            //Console.WriteLine(row);

            //Test();

            RowTest();
        }

        private static void RowTest()
        {
            var row1 = new VirtualScreenRow(20);
            var row2 = new VirtualScreenRow(20);
            var row3 = new VirtualScreenRow(20);
            row1.AddBoxTopRow(5, 3);
            row2.AddBoxMiddleRow(4, 5);
            row3.AddBoxBottomRow(3, 7);
            row1.Show();
            row2.Show();
            row3.Show();
        }

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
    }
    */
}
