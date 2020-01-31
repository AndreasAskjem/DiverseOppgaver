using System;
using System.Linq;

namespace Startliste
{
    public class Registration
    {
        public string StartNumber { get; }
        public string Name { get; }
        public string Club { get; set; }
        public string Nationality { get; }
        public string Group { get; }
        public string ClassName { get; }
        
        public Registration(string line)
        {
            var elements = line.Split(',').Select(p => p.Trim('"')).ToList();

            StartNumber = elements[0];
            Name = elements[1];
            Club = elements[2];
            Nationality = elements[3];
            Group = elements[4];
            ClassName = elements[5];
        }
    }
}