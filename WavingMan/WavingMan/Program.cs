using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WavingMan
{
    class Program
    {
        static void Main(string[] args)
        {
            var stage = new Stage();

            while (true)
            {
                stage.ShowAndMove();
                Console.CursorLeft = 0;
                Console.CursorTop = 0;
                Thread.Sleep(200);
            }
        }
    }
}
