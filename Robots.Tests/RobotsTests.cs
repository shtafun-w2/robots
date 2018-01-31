using NUnit.Framework;
using Robots.Factory;
using Robots.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Tests
{
    [TestFixture]
    public class RobotsTests
    {
        IRobotFactory _Factory;

        [SetUp]
        public void Init()
        {
            _Factory = new SimpleRobotFactory();
        }

        [Test]
        public void InitRobot()
        {
            List<IRobot> robots = new List<IRobot>();
            List<IJournal> journals = new List<IJournal>();

            IRobot r1 = _Factory.Create("Bender");

            Assert.AreEqual(0, r1.BeepCount);
            Assert.AreEqual(0, r1.Distance);
            Assert.AreEqual(0, r1.Angle);
        }

        [Test]
        public void InitUnknownRobot()
        {
            IRobot r1;

            var ex = Assert.Throws<Exception>(() => r1 = _Factory.Create("wefwef"));
            Assert.That(ex.Message, Is.EqualTo("Unknown robot type: wefwef"));
        }

        [Test]
        public void DoActions()
        {
            IRobot r1 = _Factory.Create("R2D2");

            r1.Beep();
            r1.Move(120);
            r1.Turn(90);
            r1.Move(1000);
            r1.Beep();
            r1.Turn(-45);

            Assert.AreEqual(2, r1.BeepCount);
            Assert.AreEqual(1120, r1.Distance);
            Assert.AreEqual(45, r1.Angle);
        }

        [Test]
        public void DoActionsSaveJournal()
        {
            IJournal journal = new Journal();
            IRobot r1 = _Factory.Create("Optimus", journal);

            r1.Beep();
            r1.Move(120);
            r1.Turn(90);
            r1.Move(-30);
            r1.Beep();
            r1.Turn(-45);

            Assert.AreEqual("Beep, Move, Turn, Move, Beep, Turn", journal.GetCommandLog());
        }

        [Test]
        public void DoActionsReplayJournal()
        {
            IJournal journal = new Journal();
            IRobot r1 = _Factory.Create("Optimus", journal);

            r1.Beep();
            r1.Move(120);
            r1.Turn(90);
            r1.Move(-30);
            r1.Beep();
            r1.Turn(-45);

            Assert.AreEqual("Beep, Move, Turn, Move, Beep, Turn", journal.GetCommandLog());

            IRobot r2 = _Factory.Create("R2D2");

            journal.Replay(r2);

            Assert.AreEqual(2, r2.BeepCount);
            Assert.AreEqual(150, r2.Distance);
            Assert.AreEqual(45, r2.Angle);
        }
    }
}
