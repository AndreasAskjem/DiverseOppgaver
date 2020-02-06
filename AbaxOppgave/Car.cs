using System;

namespace AbaxOppgave
{
    internal class Car : Vehicle
    {
        protected string RegistrationNumber { get; }
        protected int Speed { get; }
        protected int Effect { get; }
        protected string Color { get; }
        protected string Type { get; }
        

        public Car(string registrationNumber, int effect, int speed, string color, string type)
        {
            RegistrationNumber = registrationNumber;
            Effect = effect;
            Speed = speed;
            Color = color;
            Type = type;
        }

        

        public override void ShowData()
        {
            Console.WriteLine($"Reg. Nr.: {RegistrationNumber}kw");
            Console.WriteLine($"Effekt: {Effect}kw");
            Console.WriteLine($"Maksfart: {Speed}km/t");
            Console.WriteLine($"Farge: {Color}km/t");
            Console.WriteLine($"Type: {Type}km/t");
        }

        public override void Start()
        {
            Console.WriteLine($"Bil {RegistrationNumber} har startet å kjøre.");
        }
    }
}