using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Startliste
{
    class Program
    {
        static void Main(string[] args)
        {
            var registrations = new List<Registration>();
            var clubs = new List<Club>();

            using (var file = new StreamReader("startlist.csv", Encoding.UTF8))
            {
                var line = file.ReadLine(); // Takes out the header line

                while ((line = file.ReadLine()) != null)
                {
                    var person = new Registration(line);
                    registrations.Add(person);

                    if (person.Club == "")
                    {
                        continue;
                    }

                    if (clubs.All(club => club.ClubName != person.Club))
                    {
                        clubs.Add(new Club(person.Club));
                    }

                    var index = clubs.FindIndex(c => c.ClubName == person.Club);
                    clubs[index].AddMember(person);
                }
            }
            WriteClubsWithMembers(clubs);
        }


        private static void WriteClubsWithMembers(List<Club> clubs)
        {
            foreach (var club in clubs)
            {
                Console.WriteLine(club.ClubName);

                foreach (var person in club.Members)
                {
                    Console.WriteLine($"  {person.Name}, Class: {person.ClassName}");
                }
                Console.WriteLine();
            }
        }
    }
}