using System;

namespace Flaskeoppgave
{
    class Program
    {
        static void Main(string[] args)
        {
            var bottle1 = new Bottle(5);
            var bottle2 = new Bottle(8);
            var wantedVolume = 4;
            var numberOfOperations = 10;

            TryWithGivenNumberOfOperations(numberOfOperations, bottle1, bottle2, wantedVolume);

            
        }

        private static void TryWithGivenNumberOfOperations(int numberOfOperations, Bottle bottle1, Bottle bottle2, int wantedVolume)
        {
            Console.WriteLine("Prøver med " + numberOfOperations + " operasjon(er).");
            var operations = new int[numberOfOperations];


            //PseudoCode(operations, bottle1, bottle2, wantedVolume);


            while (true)
            {
                DoOperations(operations, bottle1, bottle2);

                /*
                var depth = 1;

                foreach (var op in operations)
                {
                    if (op == 0) { }
                }
                */

                Console.WriteLine();

                var foundSolution = CheckIfSolvedAndExitApplicationIfSo(bottle1, bottle2, wantedVolume, operations);
                if (foundSolution) break;
                var success = UpdateOperations(operations);
                if (!success) break;
            }
        }

        private static bool CheckIfSolvedAndExitApplicationIfSo(Bottle bottle1, Bottle bottle2, int wantedVolume, int[] operations)
        {
            if (bottle1.Content == wantedVolume || bottle2.Content == wantedVolume)
            {
                var output = "Fant ønsket volum ved operasjon [";
                for (var i = 0; i < operations.Length; i++)
                {
                    output += operations[i]-1;
                    if (i < operations.Length - 1)
                    {
                        output += ",";
                    }
                }
                Console.WriteLine(output + "].");
                return true;
            }

            return false;
        }

        private static void DoOperations(int[] operations, Bottle bottle1, Bottle bottle2)
        {
            bottle1.Empty();
            bottle2.Empty();
            for (var i = 0; i < operations.Length; i++)
            {
                var operationNo = operations[i] - 1;
                if(operationNo == -1) { return; }
                
                if (operationNo == 0) bottle1.FillToTopFromTap();         // Fylle flaske 1 fra springen
                else if (operationNo == 1) bottle2.FillToTopFromTap();    // Fylle flaske 2 fra springen
                else if (operationNo == 2) bottle2.Fill(bottle1.Empty()); // Tømme flaske 1 i flaske 2 - 
                // Tanken er at Empty() returnerer hvor mye det var i flasken før den ble tømt
                else if (operationNo == 3) bottle1.Fill(bottle2.Empty()); // Tømme flaske 2 i flaske 1
                else if (operationNo == 4) bottle2.FillToTop(bottle1);    // Fylle opp flaske 2 med flaske 1
                // Tanken er at FillToTop tar en annen Bottle som parameter. Hvis det er nok, fyller den 
                // bottle2 og reduserer bottle1 tilsvarende. Hvis ikke gjør den ingenting.
                else if (operationNo == 5) bottle1.FillToTop(bottle2);    // Fylle opp flaske 1 med flaske 2
                else if (operationNo == 6) bottle1.Empty();               // Tømme flaske 1 (kaste vannet)
                else if (operationNo == 7) bottle2.Empty();               // Tømme flaske 2 (kaste vannet)
            }
        }

        private static bool UpdateOperations(int[] operations)
        {
            int i;
            for (i = operations.Length - 1; i >= 0; i--)
            {
                if (operations[i] < 8)
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
