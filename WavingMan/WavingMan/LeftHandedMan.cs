using System;

namespace WavingMan
{
    internal class LeftHandedMan : Man
    {
        //public Position Position { get; }
        //public Position Speed { get; }
        //public bool IsLeftHanded { get; set; }
        //protected bool ShouldWaveNextTime = false;

        public LeftHandedMan(int x, int y, int dx, int dy)
            : base(x, y, dx, dy)
        {
            //Position = base.Position;
            //Speed = base.Speed;
        }

        public override void Show()
        {
            SetCursorTop();
            SetCursorLeft();
            Console.WriteLine(ShouldWaveNextTime ? "\\o" : " o");
            //Console.WriteLine(_shouldWaveNextTime ? (IsLeftHanded ? "\\o " : " o/") : " o");
            SetCursorLeft();
            Console.WriteLine(ShouldWaveNextTime ? " |" : "/|  ");
            //Console.WriteLine(_shouldWaveNextTime ? (IsLeftHanded ? " |\\ " : "/|") : " |");
            SetCursorLeft();
            Console.Write("/ \\");
            ShouldWaveNextTime = !ShouldWaveNextTime;
        }
    }
}