using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Startliste
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<string>();

            using (var file = new StreamReader("startlist.csv"))
            {
                string data;
                while ((data = file.ReadLine()) != null)
                {
                    //List<string> lineElements = new List<string>();

                    string[] lineElements = data.Split(',');

                    foreach (var element in lineElements)
                    {
                        Console.WriteLine(element);
                    }

                    var x = new Registration(lineElements);

                    //Console.WriteLine(line);
                }
            }
        }
    }
}
