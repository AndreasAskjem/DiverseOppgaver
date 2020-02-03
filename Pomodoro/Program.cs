﻿using System;
using PomodoroEngine;

namespace Pomodoro
{
    public class Program : INotifyObject, PomodoroEngine.INotifyObject
    {
        //private static Program _program;

        static void Main(string[] args)
        {
            var program = new Program();
            Console.ReadLine();
        }

        public Program()
        {
            var pomodoro = new PomodoroEngine.Pomodoro(this, 1);
            pomodoro.Start();
        }

        public void Tick(int minutes, int seconds)
        {
            Console.Clear();
            if (seconds == 0 && minutes == 0)
            {
                Console.WriteLine("Ta en pause!");
                Environment.Exit(0);
            }

            Console.WriteLine(minutes + ":" + seconds.ToString("00"));
        }
    }
}
