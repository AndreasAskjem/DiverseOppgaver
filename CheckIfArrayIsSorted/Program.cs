using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIfArrayIsSorted
{
    class Program
    {
        static void Main(string[] args)
        {
            if (IsSorted(args))
            {
                Console.WriteLine("It is sorted!");
            }
            else
            {
                Console.WriteLine("It is NOT sorted!");
            }
        }

        private static bool IsSorted(string[] args)
        {
            for (var i = 0; i < args.Length - 1; i++)
            {
                if (Convert.ToInt32(args[i]) > Convert.ToInt32(args[i + 1]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
