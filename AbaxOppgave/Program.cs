using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbaxOppgave
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "bil")
                {
                    //var y = new Car(147, 200);
                    var y = new Car("NF123456", 147, 200, "Grønn", "lett kjøretøy");
                    // reg. nr NF123456, 147kw effekt, maksfart 200km/t, grønn farge av typen lett kjøretøy. 
                    y.ShowData();
                    y.Start();
                }
            }
        }
    }
}