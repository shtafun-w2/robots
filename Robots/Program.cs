using Robots.Factory;
using Robots.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    class Program
    {
        static void Main(string[] args)
        {
            IRobotFactory factory = new SimpleRobotFactory();

            List<IRobot> robots = new List<IRobot>();
            List<IJournal> journals = new List<IJournal>();

            robots.Add(factory.Create("Bender"));
            robots.Add(factory.Create("Optimus"));

            foreach (var r in robots)
            {
                r.Beep();
                r.Move(120);
                r.Turn(90);
                r.Move(-30);
                r.Beep();
                r.Turn(-45);
            }

            Console.ReadLine();
        }
    }
}
