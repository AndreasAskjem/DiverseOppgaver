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
        static void Main(string[] args)
        {
            var path = @"C:\KodingForKulturlab\Modul3\DiverseOppgaver\Ordgaater\Dictionary.txt";
            var allLines = File.ReadAllLines(path, Encoding.Default);

            string[] listOfWords = GetListOfWords(allLines);

            foreach (var word in listOfWords)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine(listOfWords.Length);
        }

        private static string[] GetListOfWords(string[] allLines)
        {
            List<string> wordsInDictionary = new List<String>();
            string previousWord = "zzzzzzzzz";
            Console.WriteLine(allLines.Length);
            for (var i = 0; i < allLines.Length; i++)
            {
                string line = allLines[i];
                string[] splitLine = line.Split('\t');
                string word = splitLine[1];
                if (i > 0 && previousWord != word)
                {
                    if (word.Length > 6 && word.Length < 10 && !word.Contains("-"))
                    {
                        wordsInDictionary.Add(splitLine[1]);
                    }
                    previousWord = word;
                }
            }
            string[] result = wordsInDictionary.ToArray();
            return (result);
        }
    }
}