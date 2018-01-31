using Robots.SDK;
using System;

namespace Robots.Factory
{
    public interface IRobotFactory
    {
        IRobot Create(string robotType, IJournal journal = null);
    }

    public class SimpleRobotFactory : IRobotFactory
    {
        public IRobot Create(string robotType, IJournal journal = null)
        {
            IRobot simpleRobot = CreateRobot(robotType);

            if (journal != null)
            {
                return new JournaledRobot(simpleRobot, journal);
            }
            else
            {
                return simpleRobot;
            }
        }

        private IRobot CreateRobot(string robotType)
        {
            switch (robotType)
            {
                case "Bender":
                    return new BenderRobot();
                case "R2D2":
                    return new R2D2Robot();
                case "Optimus":
                    return new OptimusRobot();
                default:
                    throw new Exception($"Unknown robot type: {robotType}");
            }
        }
    }
}
