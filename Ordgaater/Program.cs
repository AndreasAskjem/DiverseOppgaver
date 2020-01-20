using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordgaater
{
    class Program
    {
        private static readonly Random Random = new Random();

        static void Main(string[] args)
        {
            var path = @"C:\KodingForKulturlab\Modul3\DiverseOppgaver\Ordgaater\Dictionary.txt";
            var allLines = File.ReadAllLines(path, Encoding.Default);

            string[] allWords = GetAllWords(allLines); 
            string[] filteredWords = GetFilteredWords(allWords);

            List<int> indexOfUsedWords = new List<int>();

            var count = 0;
            while (count < filteredWords.Length && indexOfUsedWords.Count < 200)
            {
                var randomIndex = -1;
                do
                {
                    randomIndex = Random.Next(0, filteredWords.Length);
                } while (indexOfUsedWords.Contains(randomIndex));

                var word = filteredWords[randomIndex];

                for (var comparisonLength = 5; comparisonLength > 2; comparisonLength--)
                {
                    for (var i = 0; i < filteredWords.Length; i++)
                    {
                        var secondWord = filteredWords[i];

                        var endOfFirstWord = word.Substring(word.Length - comparisonLength);
                        var startOfSecondWord = secondWord.Substring(0, comparisonLength);
                        if (i == randomIndex) continue;

                        if (endOfFirstWord == startOfSecondWord && allWords.Contains(endOfFirstWord))
                        {
                            Console.WriteLine($"{word} - {secondWord}");
                            indexOfUsedWords.Add(randomIndex);
                            i = filteredWords.Length;
                            comparisonLength = 2;
                        }
                    }
                }

                Console.WriteLine(count);
                count++;
            }

            Console.WriteLine(filteredWords.Length);
        }

        private static string[] GetAllWords(string[] allLines)
        {
            List<string> wordsInDictionary = new List<String>();
            string previousWord = string.Empty;
            Console.WriteLine(allLines.Length);
            for (var i = 0; i < allLines.Length; i++)
            {
                string line = allLines[i];
                string[] splitLine = line.Split('\t');
                string word = splitLine[1];
                if (i > 0 && previousWord != word)
                {
                    wordsInDictionary.Add(splitLine[1]);
                    previousWord = word;
                }
            }
            string[] result = wordsInDictionary.ToArray();
            return (result);
        }

        private static string[] GetFilteredWords(string[] allWords)
        {
            Console.WriteLine(allWords.Length);
            List<string> filteredWords = new List<String>();
            for (var i = 0; i < allWords.Length; i++)
            {
                string word = allWords[i];
                if (word.Length > 6 && word.Length < 10 && !word.Contains("-"))
                {
                    filteredWords.Add(word);
                }
            }
            string[] result = filteredWords.ToArray();
            return (result);
        }
    }
}