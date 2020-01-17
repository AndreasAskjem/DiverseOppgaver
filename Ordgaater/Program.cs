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
                System.Console.WriteLine(word);
            }
        }

        private static string[] GetListOfWords(string[] allLines)
        {
            List<string> wordsInDictionary = new List<String>();
            string previousWord = "zzzzzzzzz";
            System.Console.WriteLine(allLines.Length);
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
    }
}