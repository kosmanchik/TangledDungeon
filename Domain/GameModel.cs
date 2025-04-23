using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;


namespace TangledDungeon.Domain
{
    public class GameModel
    {
        public readonly Player Player;
        public readonly Level Level;
        private Dictionary<Keys, Action> ControlDictionary = new Dictionary<Keys, Action>();
        public static readonly float Gravity = 1.0f;
        

        public GameModel(Player player)
        {
            Player = player;
            ControlDictionary.Add(Keys.D, () => Player.UpdatePosition(Player.Speed));
            ControlDictionary.Add(Keys.A, () => {
                if (Player.Position.X - Player.Speed >= 0)
                    Player.UpdatePosition(-Player.Speed);
            });
        }

        public void ProcessInput(Keys input) //Обработка инпута
        {
            if (ControlDictionary.ContainsKey(input))
                ControlDictionary[input].Invoke();
        }

        internal void Update() // Обновление модели через игровой цикл
        {
            
        }
    }

    public class Player
    {
        public readonly int Speed;
        public Point Position { get; set; }
        private bool isOnGround = true;
        private bool isOnJump = false;

        public Player(int speed, Point position)
        {
            Speed = speed;
            Position = position;
        }

        public void UpdatePosition(int xDistance)
        {
            if (!isOnGround && !isOnJump)
            {
                Position.Y -= (int)GameModel.Gravity;
            }

            Position.X += xDistance;
        }
    }

    public class Level
    {
        private Land[] lands;
    }

    public class Land
    {
        public readonly Point Start;
        public readonly int Height;
        public readonly int Width;

        Land(Point start, int height, int width) 
        {
            Start = start;
            Height = height;
            Width = width;
        }
    }
}
