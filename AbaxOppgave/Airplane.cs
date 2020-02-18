using System;

namespace AbaxOppgave
{
    internal class Airplane : Vehicle
    {
        protected string RegistrationNumber { get; }
        protected int Effect { get; }
        protected int Wingspan { get; }
        protected int MaxLoad { get; }
        protected int Weight { get; }
        protected string Type { get; }
        //Printe informasjon om et fly med kjennetegn LN1234, 1000kw effekt, 30m vingespenn, 2tonn lasteevne, 10 tonn egenvekt I flyklasse jetfly 


        public Airplane(string registrationNumber, int effect, int wingspan, int load, int weight, string type)
        {
            RegistrationNumber = registrationNumber;
            Effect = effect;
            Wingspan = wingspan;
            MaxLoad = load;
            Weight = weight;
            Type = type;
        }

        public override void ShowData()
        {
            Console.WriteLine($"Reg. Nr.: {RegistrationNumber}");
            Console.WriteLine($"Effekt: {Effect}kw");
            Console.WriteLine($"Vingespenn: {Wingspan}m");
            Console.WriteLine($"Lasteevne: {MaxLoad} tonn");
            Console.WriteLine($"Egenvekt: {Weight}");
            Console.WriteLine($"Flyklasse: {Type}");
        }

        public override void Start()
        {
            Console.WriteLine("hello world!");
        }
    }
}