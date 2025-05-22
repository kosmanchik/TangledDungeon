using NUnit.Framework;
using NUnit.Framework.Legacy;
using TangledDungeon.Domain;

namespace Tests
{
    [TestFixture]
    public class MovementTests
    {
        private static Player TestPlayer;
        private static Level TestLevel;

        [SetUp]
        public void SetUpTests()
        {
            TestLevel = new Level([new HorizontalLand(new Point(0, 0), 100, 100), new VerticalLand(new Point(100, 0), 10, 50),
                new VerticalLand(new Point(-20, 0), 10, 50)], 
                null, new StaticEnemy[] {}, new Lever[] {});
            TestPlayer = new Player(5, new Point(0, 0), TestLevel, 50, 37);
        }

        [Test]
        public void BasicMovementTest()
        {
            TestPlayer.MovementCondition = MovementEnum.MovingLeft;
            TestPlayer.Move();

            TestPlayer.MovementCondition = MovementEnum.MovingRight;
            TestPlayer.Move();

            ClassicAssert.AreEqual(TestPlayer.Position, new Point(0, 0));
        }

        [Test]
        public void DontMoveWhenNoEnum()
        {
            var initPos = TestPlayer.Position;
            TestPlayer.Move();
            ClassicAssert.AreEqual(TestPlayer.Position, initPos);
        }

        [Test]
        public void FallingTest()
        {
            var lands = new HorizontalLand[] { new HorizontalLand(new Point(10, 20), 10, 10) };
            TestPlayer.Level = new Level(lands, null, new StaticEnemy[] { }, new Lever[] { });
            TestPlayer.Position = new Point(10, 0);
            var initHeight = 0; 
            TestPlayer.JumpCondition = JumpingEnum.Falling;
            var countItterationFalling = 0;
            while (TestPlayer.Position.Y != 20)
            {
                TestPlayer.Falling();
                countItterationFalling++;
            }

            ClassicAssert.AreEqual(TestPlayer.Position.Y, lands[0].Start.Y);
            ClassicAssert.AreEqual(GameModel.Gravity * countItterationFalling, lands[0].Start.Y - initHeight);
        }

        [Test]
        public void JumpAndMove()
        {
            TestPlayer.JumpCondition = JumpingEnum.Jumping;
            TestPlayer.MovementCondition = MovementEnum.MovingRight;
            var initPos = new Point(TestPlayer.Position);

            TestPlayer.Jump();
            TestPlayer.Move();
            var expectedPosition = new Point(initPos.X + TestPlayer.Speed, initPos.Y - TestPlayer.JumpSpeed);
            ClassicAssert.AreEqual(expectedPosition, TestPlayer.Position);
        }

        [Test]
        public void FallAndMove()
        {
            TestPlayer.Position = new Point(10, 0);
            TestPlayer.JumpCondition = JumpingEnum.Falling;
            var initPos = new Point(TestPlayer.Position);

            TestPlayer.JumpCondition = JumpingEnum.Falling;
            TestPlayer.MovementCondition = MovementEnum.MovingRight;
            TestPlayer.Falling();
            TestPlayer.Move();
            var expectedPosition = new Point(initPos.X + TestPlayer.Speed, initPos.Y + GameModel.Gravity);
            ClassicAssert.AreEqual(expectedPosition, TestPlayer.Position);
        }

        [Test]
        public void VerticalLandRightCollision()
        {
            TestPlayer.Position.X = 100;
            var initPosition = new Point(TestPlayer.Position);
            TestPlayer.MovementCondition = MovementEnum.MovingRight;
            TestPlayer.Move();

            ClassicAssert.AreEqual(initPosition, TestPlayer.Position);
        }

        [Test]
        public void VerticalLandLeftCollision()
        {
            TestPlayer.Position.X = -20;
            var initPosition = new Point(TestPlayer.Position);
            TestPlayer.MovementCondition = MovementEnum.MovingLeft;
            TestPlayer.Move();

            ClassicAssert.AreEqual(initPosition, TestPlayer.Position);
        }
    }
}


