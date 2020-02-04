using System;
using System.Threading;

namespace WavingMan
{
    public class Stage
    {
        private readonly Man[] _men = new Man[]
        {
            new Man(5,5,-1,0), new Man(6,5,1,0),  new Man(5,6,0,1){IsLeftHanded = true}, 
        };

        public void ShowAndMove()
        {
            Console.Clear();
            foreach (var person in _men)
            {
                person.Show();
                person.Move();
            }

        }
    }
}
