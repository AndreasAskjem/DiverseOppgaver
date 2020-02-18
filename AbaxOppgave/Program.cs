using System;
//using System.Collections.Generic;

namespace AbaxOppgave
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = GetCars();

            var airplanes = GetPlanes();

            //Console.WriteLine(cars[1].RegistrationNumber == cars[2].RegistrationNumber);

            while (true)
            {
                var input = Console.ReadLine();

                
                if (input == "bil 1")
                {
                    cars[0].Options();

                    // reg. nr NF123456, 147kw effekt, maksfart 200km/t, grønn farge av typen lett kjøretøy.
                }
                if (input == "bil 2")
                {
                    cars[1].Options();

                    // reg. nr NF654321, 150kw effekt, maksfart 195km/t, blå farge og av typen lett kjøretøy
                }

                if (input == "fly")
                {
                    airplanes[0].Options();
                }
                
            }
        }

        private static Airplane[] GetPlanes()
        {
            var plane1 = new Airplane("LN1234", 1000, 30, 2, 20, "jetfly");
            var plane2 = new Airplane("LN1235", 1000, 30, 2, 20, "jetfly");

            Airplane[] planes = { plane1, plane2 };
            return planes;
            //Printe informasjon om et fly med kjennetegn LN1234, 1000kw effekt, 30m vingespenn, 2tonn lasteevne, 10 tonn egenvekt I flyklasse jetfly 
        }

        private static Car[] GetCars()
        {
            var car1 = new Car("NF123456", 147, 200, "Grønn", "lett kjøretøy");
            var car2 = new Car("NF654321", 150, 195, "Blå", "lett kjøretøy");
            var car3 = new Car("NF654321", 150, 195, "Blå", "lett kjøretøy");

            Car[] cars = { car1, car2, car3 };
            return cars;
        }
    }
}