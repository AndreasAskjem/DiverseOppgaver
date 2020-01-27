using System;

namespace Flaskeoppgave
{
    internal class Bottle
    {
        public int Capacity { get; }
        public int Content { get; set; }

        public Bottle(int capacity)
        {
            Capacity = capacity;
        }

        public int Empty()
        {
            var pouredOut = Content;
            Content = 0;
            return pouredOut;
        }

        internal void FillToTopFromTap()
        {
            Content = Capacity;
        }

        internal void Fill(int otherBottle)
        {
            Content += otherBottle;
            Content = Content > Capacity ? Capacity : Content;
        }

        internal void FillToTop(Bottle otherBottle)
        {
            if (Capacity - Content > otherBottle.Content) {return;}

            otherBottle.Content = Content + otherBottle.Content - Capacity;
            Content = Capacity;
            Console.WriteLine();

            /*
            Content += otherBottle.Empty();

            if (Content > Capacity)
            {
                otherBottle.Content = Content - Capacity;
                Content = Capacity;
            }
            */
        }
    }
}