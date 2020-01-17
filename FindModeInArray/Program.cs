using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindModeInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = {3, 6, 3, 2, 1, 3, 6, 5, 3, 3, 9};
            Array.Sort(myArray);

            int currentStreak = 1;
            int longestStreak = 1;
            int valueOfLongestStreak = 0;
            
            for ( var i = 0; i < myArray.Length-1; i++ )
            {
                var num = myArray[i];
                var nextNum = myArray[i + 1];
                if (num == nextNum)
                {
                    currentStreak++;
                }
                else if (currentStreak > longestStreak)
                {
                    longestStreak = currentStreak;
                    currentStreak = 1;
                    valueOfLongestStreak = myArray[i];
                }
            }

            Console.WriteLine($"Mode: {valueOfLongestStreak}");
            Console.WriteLine($"Occurrences of the mode: {longestStreak}");
        }
    }
}
