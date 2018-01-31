using Robots.SDK;
using System.Collections.Generic;
using System.Linq;

namespace Robots.Factory
{
    public interface IJournal
    {
        void SaveCommand(ICommand cmd);
        string GetCommandLog();
        void Replay(IRobot robot);
    }

    public class Journal : IJournal
    {
        public IList<ICommand> Commands { get; private set; } = new List<ICommand>();

        public void SaveCommand(ICommand cmd)
        {
            Commands.Add(cmd);
        }

        public string GetCommandLog()
        {
            return string.Join(", ", Commands.Select(c => c.Name));
        }

        public void Replay(IRobot robot)
        {
            foreach (var cmd in Commands)
                cmd.Execute(robot);
        }
    }
}
