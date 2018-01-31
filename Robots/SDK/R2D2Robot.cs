using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.SDK
{
    public class R2D2Robot : IRobot
    {
        public double Distance { get; private set; } = 0;

        public double Angle { get; private set; } = 0;

        public int BeepCount { get; private set; } = 0;

        public void Beep()
        {
            BeepCount++;
            Console.WriteLine($"R2D2 does {Utilities.GetCaller()}");
        }

        public void Move(double distance)
        {
            Distance += Math.Abs(distance);
            Console.WriteLine($"R2D2 does {Utilities.GetCaller()} on {distance}");
        }

        public void Turn(double angle)
        {
            Angle += angle;
            Console.WriteLine($"R2D2 does {Utilities.GetCaller()} on {angle}");
        }
    }
}
