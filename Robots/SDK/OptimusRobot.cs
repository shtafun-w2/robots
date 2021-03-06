﻿using System;

namespace Robots.SDK
{
    public class OptimusRobot : IRobot
    {
        public double Distance { get; private set; } = 0;

        public double Angle { get; private set; } = 0;

        public int BeepCount { get; private set; } = 0;

        public void Beep()
        {
            BeepCount++;
            Console.WriteLine($"Optimus does {Utilities.GetCaller()}");
        }

        public void Move(double distance)
        {
            Distance += Math.Abs(distance);
            Console.WriteLine($"Optimus does {Utilities.GetCaller()} on {distance}");
        }

        public void Turn(double angle)
        {
            Angle += angle;
            Console.WriteLine($"Optimus does {Utilities.GetCaller()} on {angle}");
        }
    }
}
