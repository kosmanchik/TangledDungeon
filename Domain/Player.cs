using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangledDungeon.Domain
{
    public class Player
    {
        public readonly int Speed;
        public readonly int Height;
        public readonly int Width;
        public readonly int JumpSpeed = 2;
        private int JumpHeight = 25;
        private int CurrentJumpHeight = 0;
        
        private Level Level;
        public Point Position { get; set; }
        public MovementEnum MovementCondition { get; set; }
        public JumpingEnum JumpCondition { get; set; }

        public Player(int speed, Point position, Level level, int width, int height)
        {
            Speed = speed;
            Position = position;
            Level = level;
            Width = width;
            Height = height;
        }

        public void Jump()
        {
            if (CurrentJumpHeight < JumpHeight)
            {
                Position.Y -= JumpSpeed;
                CurrentJumpHeight++;
            }

            if (CurrentJumpHeight == JumpHeight)
                JumpCondition = JumpingEnum.Falling;
        }

        public void Falling()
        {
            Position.Y += GameModel.Gravity;
            if (Level.IsOnLand(Position, 50, 37))
            {
                JumpCondition = JumpingEnum.Staying;
                CurrentJumpHeight = 0;
            }
        }

        public void Move()
        {
            if (MovementCondition == MovementEnum.MovingLeft)
                Position.X -= Speed;
            else if (MovementCondition == MovementEnum.MovingRight)
                Position.X += Speed;
        }
    }
}
