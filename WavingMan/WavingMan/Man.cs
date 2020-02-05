using System;

namespace WavingMan
{
    public class Man
    {
        public Position Position { get; }
        public Position Speed { get; }
        //public bool IsLeftHanded { get; set; }
        protected bool ShouldWaveNextTime = false;

        public Man(int x, int y, int dx, int dy)
        {

            Position = new Position(x, y);
            Speed = new Position(dx, dy);
        }

        public virtual void Show()
        {
            SetCursorTop();
            SetCursorLeft();
            Console.WriteLine(ShouldWaveNextTime ? " o/" : " o");
            //Console.WriteLine(_shouldWaveNextTime ? (IsLeftHanded ? "\\o " : " o/") : " o");
            SetCursorLeft();
            Console.WriteLine(ShouldWaveNextTime ? " |" : " |\\ ");
            //Console.WriteLine(_shouldWaveNextTime ? (IsLeftHanded ? " |\\ " : "/|") : " |");
            SetCursorLeft();
            Console.Write("/ \\");
            ShouldWaveNextTime = !ShouldWaveNextTime;
        }

        protected void SetCursorTop()
        {
            Console.CursorTop = Math.Max(Position.Y, 0);
        }

        protected void SetCursorLeft()
        {
            Console.CursorLeft = Math.Max(Position.X - 1, 0);
        }

        public void Move()
        {
            var windowWidth = Console.WindowWidth;
            var windowHeight = Console.WindowHeight;

            if (Position.X <= 1) Speed.X = 1;
            if (Position.X >= windowWidth - 3) Speed.X = -1;
            if (Position.Y <= 1) Speed.Y = 1;
            if (Position.Y >= windowHeight - 3) Speed.Y = -1;

            Position.Move(Speed);
        }
    }
}
