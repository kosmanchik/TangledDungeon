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
        public readonly Level Level;
        public static readonly int Gravity = 2;
        public int Width { get; set; }
        public int Height { get; set; }
        
        public GameModel(Player player, Level level)
        {
            Level = level;
            Player = player;
        }

        internal void Tick()
        {
            if (Player.JumpCondition == JumpingEnum.Jumping)
                Player.Jump();
            if (Player.JumpCondition == JumpingEnum.Falling)
                Player.Falling();

            if (Player.MovementCondition == MovementEnum.MovingLeft 
                || Player.MovementCondition == MovementEnum.MovingRight)
                Player.Move();
        }
    }
}
