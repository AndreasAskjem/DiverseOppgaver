using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DrawShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please run the program with the numbers 1, 2 or 3 as an argument.");
                return;
            }
            if (args[0] == "1")
            {
                HalfDiamond();
            }
            else if (args[0] == "2")
            {
                Diamond();
            }
            else if (args[0] == "3")
            {
                Star();
            }
            else
            {
                Console.WriteLine("Please run the program with the numbers 1, 2 or 3 as an argument.");
            }
        }

        private static void HalfDiamond()
        {
            Console.WriteLine("Half Diamond:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(" ");
                }

                for (int j = 0; j < 8 - i * 2; j++)
                {
                    Console.Write("#");
                }
                Console.WriteLine();
            }
        }

        private static void Diamond()
        {
            Console.WriteLine("Diamond:");

            int spaces = 0;
            int hashMarks = 0;
            for (int i = 0; i < 8; i++)
            {
                int difference1 = 3 - i * 2;
                if (difference1 < -4) difference1 = -4;
                spaces = i+difference1;

                hashMarks = (4 - spaces)*2;

                for (int j = 0; j < spaces; j++)
                {
                    Console.Write(" ");
                }

                for (int j = 0; j < hashMarks; j++)
                {
                    Console.Write("#");
                }
                Console.WriteLine();

            }
        }

        private static void Star()
        {
            Console.WriteLine("Star:");

            for (int i = 0; i < 8; i++)
            {
                int spaces1 = i;
                if (i > 3) spaces1 = 7 - i;
                var hashes = spaces1 + 1;
                var spaces2 = 14 - (spaces1 + hashes) * 2;

                for (int j = 0; j < spaces1; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < hashes; j++)
                {
                    Console.Write("#");
                }
                for (int j = 0; j < spaces2; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < hashes; j++)
                {
                    Console.Write("#");
                }

                Console.WriteLine();
            }
            //" " # " " #
            // 0  1 12  1
            // 1  2  8  2
            // 2  3  4  3
            // 3  4  0  4
            // 3  4  0  4
            // 2  3  4  3
            // 1  2  8  2
            // 0  1 12  1

            // Spaces1: i=0-3 -> i | i=4-7 -> 7-i
            // Hashes: Spaces1 + 1
            // Spaces2: Abs(Spaces1 -3)*4
            // Spaces2: 14 - (Spaces1 + Hashes)*2
        }
    }
}
