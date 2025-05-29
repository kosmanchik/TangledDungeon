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
    public class EnemyShould
    {
        private static Player TestPlayer;
        private static Level[] TestLevels;

        [SetUp]
        public void SetUpTests()
        {
            TestLevels = new Level[1];
            TestLevels[0] = new Level([], null, [new StaticEnemy(new Point(0, 0), 100, 100)], []);
            TestPlayer = new Player(5, new Point(0, 0), TestLevels[0], 50, 37);
        }

        [Test]
        public void SpawnIntoEnemy()
        {
            TestPlayer.CheckDeath();
            ClassicAssert.IsTrue(TestPlayer.IsDead);
        }

        [Test]
        public void NotDeadWhenNoCollision()
        {
            TestPlayer.Position.X += 200;
            TestPlayer.CheckDeath();
            ClassicAssert.IsFalse(TestPlayer.IsDead);
        }

        [Test]
        public void DeadWhenMoveIn()
        {
            TestPlayer.Position.X = -5;
            TestPlayer.MovementCondition = MovementEnum.MovingRight;
            TestPlayer.Move();
            TestPlayer.CheckDeath();
            ClassicAssert.IsTrue(TestPlayer.IsDead);
        }

        [Test]
        public void DeadWhenJumpIn()
        {
            TestPlayer.Position.Y = 5;
            TestPlayer.JumpCondition = JumpingEnum.Jumping;
            TestPlayer.Jump();
            TestPlayer.CheckDeath();
            ClassicAssert.IsTrue(TestPlayer.IsDead);
        }

        [Test]
        public void DeadWhenFallIn()
        {
            TestPlayer.Position.Y = -5;
            TestPlayer.JumpCondition = JumpingEnum.Falling;
            TestPlayer.Falling();
            TestPlayer.CheckDeath();
            ClassicAssert.IsTrue(TestPlayer.IsDead);
        }
    }
}
