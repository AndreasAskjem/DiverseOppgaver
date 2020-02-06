using System;
using System.Collections.Generic;

namespace AbaxOppgave
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = getCars();

            while (true)
            {
                var input = Console.ReadLine();

                
                if (input == "bil 1")
                {
                    cars[0].options();

                    // reg. nr NF123456, 147kw effekt, maksfart 200km/t, grønn farge av typen lett kjøretøy.
                }
                if (input == "bil 2")
                {
                    cars[1].options();

                    // reg. nr NF654321, 150kw effekt, maksfart 195km/t, blå farge og av typen lett kjøretøy
                }

                if (input == "fly")
                {

                }
                
            }
        }

        private static Car[] getCars()
        {
            var car1 = new Car("NF123456", 147, 200, "Grønn", "lett kjøretøy");
            var car2 = new Car("NF654321", 150, 195, "Blå", "lett kjøretøy");

            Car[] cars = { car1, car2 };
            return cars;
        }
    }
}