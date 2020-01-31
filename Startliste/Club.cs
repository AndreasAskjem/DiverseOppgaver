using System.Collections.Generic;

namespace Startliste
{
    public class Club
    {
        public string ClubName { get; set; }
        public List<Registration> Members { get; set; } = new List<Registration>();

        public Club(string clubName)
        {
            ClubName = clubName;
        }

        public void AddMember(Registration person)
        {
            //if (person == null) return;
            Members.Add(person);
        }
    }
}