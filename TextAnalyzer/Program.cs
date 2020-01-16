using System;
//using System.Collections.Generic;
//using System.Diagnostics;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace TextAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("You need an input!");
                return;
            }

            WordCounter(args);

            LongestWord(args);

            FindMostVowels(args);
        }

        private static void FindMostVowels(string[] args)
        {
            const string vowels = "aeiouy";
            var indexOfMostVowels = 0;
            var mostVowels = 0;
            for (var i = 0; i < args.Length; i++)
            {
                var s = args[i];
                var numberOfVowels = 0;
                foreach (var c in s)
                {
                    if (vowels.Contains(c))
                    {
                        numberOfVowels++;
                    }
                }

                if (numberOfVowels > mostVowels)
                {
                    indexOfMostVowels = i;
                    mostVowels = numberOfVowels;
                }
            }
            Console.WriteLine($"The word \"{args[indexOfMostVowels]}\" has most vowels, with {mostVowels} of them.");
        }

        private static void LongestWord(string[] args)
        {
            var indexOfLongestWord = 0;
            for (var i = 0; i < args.Length - 1; i++)
            {
                var s = args[i];
                if (s.Length > indexOfLongestWord)
                {
                    indexOfLongestWord = i;
                }
            }

            var longestWord = args[indexOfLongestWord];
            var length = longestWord.Length;
            Console.WriteLine($"The longest word is {longestWord}, with a length of {length} characters.");
        }

        private static void WordCounter(string[] args)
        {
            Console.WriteLine($"The input has a total of {args.Length} words.");
        }
    }
}
