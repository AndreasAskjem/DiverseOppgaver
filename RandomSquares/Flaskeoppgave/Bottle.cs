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

        internal void Fill(int otherBottleContent)
        {
            if (Content + otherBottleContent <= Capacity)
            {
                Content += otherBottleContent;
            }

            //Content = Content > Capacity ? Capacity : Content;
        }

        internal void FillToTop(Bottle otherBottle)
        {
            if (Content + otherBottle.Content <= Capacity) return;

            otherBottle.Content -= (Capacity - Content);
            Content = Capacity;
        }
    }
}