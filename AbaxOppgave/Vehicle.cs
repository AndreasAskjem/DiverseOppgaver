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
    }
}