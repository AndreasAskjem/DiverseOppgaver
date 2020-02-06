using System;
using System.Runtime.InteropServices;

namespace AbaxOppgave
{
    internal abstract class Vehicle
    {
        public Vehicle()
        {
        }

        public abstract void ShowData();

        public abstract void Start();

        public void options()
        {
            Console.WriteLine("Hva vil du gjøre?");
            var input = Console.ReadLine();

            if (input == "vis")
            {
                ShowData();
            }

            if (input == "start")
            {
                Start();
            }
        }
    }
}