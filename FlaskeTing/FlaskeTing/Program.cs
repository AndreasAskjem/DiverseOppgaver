using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace FlaskeTing
{
    class Program
    {
        private static string[] operationNames = new[]
        {
            "Fylle flaske 1 fra springen",
            "Fylle flaske 2 fra springen",
            "Tømme flaske 1 i flaske 2",
            "Tømme flaske 2 i flaske 1",
            "Fylle opp flaske 2 med flaske 1",
            "Fylle opp flaske 1 med flaske 2",
            "Tømme flaske 1 (kaste vannet)",
            "Tømme flaske 2 (kaste vannet)",
        };

        static void Main()
        {
            var bottle1 = new Bottle(5);
            var bottle2 = new Bottle(7);
            var wantedVolume = 1;

            var numberOfOperations = 1;
            while (true)
            {
                var isSolved = TryWithGivenNumberOfOperations(numberOfOperations, bottle1, bottle2, wantedVolume);
                if (isSolved)
                {
                    break;
                }
                numberOfOperations++;
            }
        }

        private static bool TryWithGivenNumberOfOperations(int numberOfOperations, Bottle bottle1, Bottle bottle2, int wantedVolume)
        {
            Console.WriteLine("Prøver med " + numberOfOperations + " operasjon(er).");
            var operations = new int[numberOfOperations];
            while (true)
            {
                DoOperations(operations, bottle1, bottle2);
                var isSolved = IsSolved(bottle1, bottle2, wantedVolume, operations);
                if (isSolved) return true;
                var success = UpdateOperations(operations);
                if (!success) break;
            }

            return false;
        }

        private static bool IsSolved(
            Bottle bottle1, Bottle bottle2, 
            int wantedVolume, int[] operations)
        {
            if (bottle1.Content != wantedVolume
             && bottle2.Content != wantedVolume
             && bottle1.Content + bottle2.Content != wantedVolume)
                return false;
            for (var i = 0; i < operations.Length; i++)
            {
                var operation = operations[i];
                Console.WriteLine((i+1)+": " + operationNames[operation]);
            }

            return true;
        }

        private static void DoOperations(int[] operations, Bottle bottle1, Bottle bottle2)
        {
            bottle1.Empty();
            bottle2.Empty();
            foreach (var operation in operations)
            {
                if (operation == 0) bottle1.FillToTopFromTap();         // Fylle flaske 1 fra springen
                else if (operation == 1) bottle2.FillToTopFromTap();    // Fylle flaske 2 fra springen
                else if (operation == 2) bottle2.Fill(bottle1.Empty()); // Tømme flaske 1 i flaske 2 - 
                // Tanken er at Empty() returnerer hvor mye det var i flasken før den ble tømt
                else if (operation == 3) bottle1.Fill(bottle2.Empty()); // Tømme flaske 2 i flaske 1
                else if (operation == 4) bottle2.FillToTop(bottle1);    // Fylle opp flaske 2 med flaske 1
                // Tanken er at FillToTop tar en annen Bottle som parameter. Hvis det er nok, fyller den 
                // bottle2 og reduserer bottle1 tilsvarende. Hvis ikke gjør den ingenting.
                else if (operation == 5) bottle1.FillToTop(bottle2);    // Fylle opp flaske 1 med flaske 2
                else if (operation == 6) bottle1.Empty();               // Tømme flaske 1 (kaste vannet)
                else if (operation == 7) bottle2.Empty();               // Tømme flaske 2 (kaste vannet)
            }
        }

        private static bool UpdateOperations(int[] operations)
        {
            int i;
            for (i = operations.Length - 1; i >= 0; i--)
            {
                if (operations[i] < 7)
                {
                    operations[i]++;
                    break;
                }
                operations[i] = 0;
            }
            return i != -1;
        }
    }
}
