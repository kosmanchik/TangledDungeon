using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using TangledDungeon.Domain;

namespace Tests
{
    [TestFixture]
    public class ExitTests
    {
        private static Player TestPlayer;
        private static Level[] TestLevels;
        private static GameModel Model;

        [SetUp]
        public void SetUpTests()
        {
            TestLevels = new Level[2];
            TestLevels[0] = new Level([], new Exit(new Point(0, 0)), [], []);
            TestLevels[1] = new Level([],new Exit(new Point(0, 0)), [], []);
            TestPlayer = new Player(5, new Point(0, 0), TestLevels[0], 50, 37);
            Model = new GameModel(TestPlayer, TestLevels);
        }

        [Test]
        public void BasicExitTest()
        {
            Model.ExitLevel();
            ClassicAssert.AreEqual(TestPlayer.Level, TestLevels[1]);
        }

        [Test]
        public void NoExitTest()
        {
            TestPlayer.Position.X += 100;
            Model.ExitLevel();
            ClassicAssert.AreEqual(TestPlayer.Level, TestLevels[0]);
        }

        [Test]
        public void ExitOnTheLastLevel()
        {
            for (int i = 0; i < TestLevels.Length; i++)
            {
                Model.ExitLevel();
            }
            ClassicAssert.AreEqual(TestPlayer.Level, Level.EmptyLevel);
        }
    }
}
