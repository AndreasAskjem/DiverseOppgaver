using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeoppgave
{
    class Program
    {
        static void Main(string[] args)
        {
            var bottle1 = new Bottle(5);
            var bottle2 = new Bottle(7);
            var wantedVolume = 2;
            var numberOfOperations = 8;

            TryWithGivenNumberOfOperations(numberOfOperations, bottle1, bottle2, wantedVolume);

            
        }

        private static void TryWithGivenNumberOfOperations(int numberOfOperations, Bottle bottle1, Bottle bottle2, int wantedVolume)
        {
            Console.WriteLine("Prøver med " + numberOfOperations + " operasjon(er).");
            var operations = new int[numberOfOperations];
            while (true)
            {
                DoOperations(operations, bottle1, bottle2, wantedVolume);
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
                    output += operations[i];
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

        private static void DoOperations(int[] operations, Bottle bottle1, Bottle bottle2, int wantedVolume)
        {
            //Noe med operations[i]???

            for (var operationNo = 0; operationNo < 8; operationNo++)
            {
                bottle1.Empty();
                bottle2.Empty();
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


                //Console.WriteLine($"b1: {bottle1.Content}, b2: {bottle2.Content}");

                if (bottle1.Content == wantedVolume || bottle2.Content == wantedVolume)
                {
                    Console.WriteLine("Fant ønsket volum ved operasjon " + operationNo);
                }
            }
        }

        private static bool UpdateOperations(int[] operations)
        {
            int i;
            //Console.WriteLine(operations.Length);
            for (i = operations.Length - 1; i >= 0; i--)
            {
                if (operations[i] < 8)
                {
                    operations[i]++;
                    break;
                }
                operations[i] = 0;
            }
            /*
            foreach (var number in operations)
            {
                Console.Write(number + ", ");
            }
            Console.WriteLine($"i = {i}");
            */
            return i != -1;
        }

        
    }
}
