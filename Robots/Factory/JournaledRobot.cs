
using Robots.SDK;

namespace Robots.Factory
{
    public class JournaledRobot : IRobot
    {
        private IRobot _Robot;
        private IJournal _Journal;

        public JournaledRobot(IRobot r, IJournal journal)
        {
            _Robot = r;
            _Journal = journal;
        }

        public double Distance => _Robot.Distance;

        public double Angle => _Robot.Angle;

        public int BeepCount => _Robot.BeepCount;

        public void Beep()
        {
            _Journal.SaveCommand(new BeepCommand());
            _Robot.Beep();
        }

        public void Move(double distance)
        {
            _Journal.SaveCommand(new MoveCommand(distance));
            _Robot.Move(distance);
        }

        public void Turn(double angle)
        {
            _Journal.SaveCommand(new TurnCommand(angle));
            _Robot.Turn(angle);
        }
    }
}
