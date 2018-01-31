using Robots.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Factory
{
    public interface ICommand
    {
        string Name { get; }
        IList<object> Parameters { get; }
        void Execute(IRobot target);
    }

    public class MoveCommand : ICommand
    {
        public MoveCommand(double p)
        {
            Parameters = new List<object>() { p };
        }

        public string Name => "Move";
        public IList<object> Parameters { get; private set; }

        public void Execute(IRobot target)
        {
            target.Move(Double.Parse(Parameters.Single().ToString()));
        }
    }

    public class TurnCommand : ICommand
    {
        public TurnCommand(double p)
        {
            Parameters = new List<object>() { p };
        }

        public string Name => "Turn";
        public IList<object> Parameters { get; private set; }

        public void Execute(IRobot target)
        {
            target.Turn(Double.Parse(Parameters.Single().ToString()));
        }
    }

    public class BeepCommand : ICommand
    {
        public string Name => "Beep";
        public IList<object> Parameters { get; private set; } = new List<object>();

        public void Execute(IRobot target)
        {
            target.Beep();
        }
    }
}
