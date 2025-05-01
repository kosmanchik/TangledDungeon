using NUnit.Framework;
using NUnit.Framework.Legacy;
using TangledDungeon.Domain;

namespace Tests
{
    [TestFixture]
    public class MovementTests
    {
        [Test]
        public void BasicMovementTest()
        {
            var testPlayer = new Player(5, new Point(0, 0), null, 50, 37);
            testPlayer.MovementCondition = MovementEnum.MovingLeft;
            testPlayer.Move();

            testPlayer.MovementCondition = MovementEnum.MovingRight;
            testPlayer.Move();

            ClassicAssert.AreEqual(testPlayer.Position, new Point(0, 0));
        }
    }
}


