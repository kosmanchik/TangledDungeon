using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;


namespace TangledDungeon.Domain
{
    public class GameModel
    {
        public readonly Player Player;
        public readonly Level[] Levels;
        private Point PlayerStartPosition;
        private int CurrentLevelIndex = 0;
        public static readonly int Gravity = 4;
        public int Width { get; set; }
        public int Height { get; set; }
        public Level currentLevel;

        public GameModel(Player player, Level[] levels)
        {
            Levels = levels;
            currentLevel = levels[0];
            Player = player;
            PlayerStartPosition = new Point(player.Position);
        }

        internal void Tick()
        {
            if (Player.JumpCondition == JumpingEnum.Jumping)
                Player.Jump();
            if (Player.JumpCondition == JumpingEnum.Falling)
                Player.Falling();

            if (Player.MovementCondition == MovementEnum.MovingLeft 
                || Player.MovementCondition == MovementEnum.MovingRight)
            {
                Player.Move();
                if (Player.Position.X + Player.Width > Width || Player.Position.X + Player.Width < 0
                    || Player.Position.Y + Player.Height < 0 || Player.Position.Y - Player.Height > Height)
                    Player.IsDead = true;
            }
                
        }

        public Level ExitLevel()
        {
            var exitPoint = currentLevel.GetExitPoint();
            if (Player.Position.X + Player.Width > exitPoint.X && Player.Position.X < exitPoint.X + 50
                && Player.Position.Y + Player.Height > exitPoint.Y && Player.Position.Y < exitPoint.Y + 50)
            {
                if (CurrentLevelIndex + 1 < Levels.Length)
                {
                    currentLevel = Levels[CurrentLevelIndex + 1];
                    CurrentLevelIndex++;
                    Player.Level = currentLevel;
                    return currentLevel;
                }
                else
                    Player.Level = Level.EmptyLevel;
            }

            return Level.EmptyLevel;
        }

        public LandCommand PushLever() => currentLevel.PushLever(Player.Position, Player.Width, Player.Height);

        public void RestartLevel()
        {
            Player.Position = new Point(PlayerStartPosition);
            Player.IsDead = false;
        }
    }
}
