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
        public readonly int JumpSpeed = 4;
        private int JumpHeight = 20;
        private int CurrentJumpHeight = 0;
        public Level Level;
        public Point Position { get; set; }
        public MovementEnum MovementCondition { get; set; }
        public JumpingEnum JumpCondition { get; set; }
        public bool IsDead { get; set; }

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
            CheckDeath();

            if (CurrentJumpHeight == JumpHeight)
                JumpCondition = JumpingEnum.Falling;
        }

        public void Falling()
        {
            Position.Y += GameModel.Gravity;
            CheckDeath();

            if (Level.IsOnHorizontalLand(Position, Width, Height))
            {
                JumpCondition = JumpingEnum.Staying;
                CurrentJumpHeight = 0;
            }
        }

        public void Move()
        {
            if (!Level.IsOnHorizontalLand(Position, Width, Height) && JumpCondition != JumpingEnum.Jumping)
                JumpCondition = JumpingEnum.Falling;

            if (MovementCondition == MovementEnum.MovingLeft && !Level.IsOnVerticalLand(Position, Width, Height))
                Position.X -= Speed;
            else if (Level.IsOnVerticalLand(Position, Width, Height))
            {
                Position.X -= 5 * Speed;
                MovementCondition = MovementEnum.Staying;
            }

            if (MovementCondition == MovementEnum.MovingRight && !Level.IsOnVerticalLand(Position, Width, Height))
                Position.X += Speed;
            else if (Level.IsOnVerticalLand(Position, Width, Height))
            {
                Position.X += 5 * Speed;
                MovementCondition = MovementEnum.Staying;
            }
                
            CheckDeath();
        }

        public void CheckDeath()
        {
            if (Level.IsEnemyCollision(Position, Width, Height))
                IsDead = true;
        }
    }
}
