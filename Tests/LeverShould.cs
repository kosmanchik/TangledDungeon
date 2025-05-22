using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangledDungeon.Domain;

namespace Tests
{
    [TestFixture]
    public class LeverTests
    {
        private static Player TestPlayer;
        private static Level TestLevel;

        [SetUp]
        public void SetUpTests()
        {
            TestLevel = new Level([new HorizontalLand(new Point(0, 0), 100, 10), new VerticalLand(new Point(0, 0), 10, 50)],
                new Exit(new Point(0, 0)), [],
                [new Lever(new Point(0, 0), 0)]);
            TestPlayer = new Player(5, new Point(0, 0), TestLevel, 50, 37);
        }

        [Test]
        public void LandDestroy()
        {
            var lands = TestLevel.GetLands();
            var landCommand = TestLevel.PushLever(TestPlayer.Position, TestPlayer.Width, TestPlayer.Height);

            ClassicAssert.AreNotEqual(landCommand, LandCommand.EmptyCommand);
            ClassicAssert.AreEqual(TestLevel.GetLands().Length, lands.Length);
            ClassicAssert.AreEqual(TestLevel.GetLands()[landCommand.Index], landCommand.LandStatus);
        }

        [Test]
        public void LandRestore()
        {
            LandDestroy();
            var lands = TestLevel.GetLands();
            var landCommand = TestLevel.PushLever(TestPlayer.Position, TestPlayer.Width, TestPlayer.Height);

            ClassicAssert.AreNotEqual(landCommand, LandCommand.EmptyCommand);
            ClassicAssert.AreEqual(TestLevel.GetLands().Length, lands.Length);
            ClassicAssert.AreEqual(TestLevel.GetLands()[landCommand.Index], landCommand.LandStatus);
        }

        [Test]
        public void NoDestroyWhenNoCollision()
        {
            TestPlayer.Position.X = -100;
            var initLands = TestLevel.GetLands();
            TestLevel.PushLever(TestPlayer.Position, TestPlayer.Width, TestPlayer.Height);

            for (int i = 0; i < initLands.Length; i++)
                ClassicAssert.AreNotEqual(initLands[i], ILand.EmptyLand);
        }
    }
}
