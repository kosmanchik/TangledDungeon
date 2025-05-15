using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace TangledDungeon.Domain
{
    public class Level
    {
        private Land[] Lands;
        private Exit LevelExit;
        private StaticEnemy[] StaticEnemies;
        private Lever[] Levers;


        public static Level EmptyLevel = new Level(null, null, null, null);
        private Level currentLevel;

        public Level(Land[] lands, Exit levelExit, StaticEnemy[] staticEnemies, Lever[] levers)
        {
            Lands = lands;
            LevelExit = levelExit;
            StaticEnemies = staticEnemies;
            Levers = levers;
        }

        public Level(Level level)
        {
            Lands = level.Lands;
            LevelExit = level.LevelExit;
            StaticEnemies = level.StaticEnemies;
            Levers = level.Levers;
        }

        public bool IsOnLand(Point playerPosition, int playerWidth, int playerHeight)
        {
            var playerRectangle = new Rectangle(playerPosition.X, playerPosition.Y, playerWidth, playerHeight);
            foreach (var land in Lands)
            {
                if (land == Land.EmptyLand)
                    continue;
                var landRectangle = new Rectangle(land.Start.X, land.Start.Y, land.Width, land.Height);
                if (landRectangle.IntersectsWith(playerRectangle))
                    return true;
            }
            return false;
        }

        public bool IsEnemyCollision(Point playerPosition, int playerWidth, int playerHeight)
        {
            foreach (var enemy in StaticEnemies)
            {
                if (playerPosition.X + playerWidth > enemy.Position.X && playerPosition.X < enemy.Position.X + enemy.Width &&
                    playerPosition.Y + playerHeight >= enemy.Position.Y && playerPosition.Y + playerHeight <= enemy.Position.Y + enemy.Height)
                    return true;
            }
            return false;
        }

        public Point GetExitPoint()
        {
            return new Point(LevelExit.Position);
        }

        public Land[] GetLands()
        {
            return (Land[])Lands.Clone();
        }

        public StaticEnemy[] GetStaticEnemies()
        {
            return (StaticEnemy[])StaticEnemies.Clone();
        }

        public Lever[] GetLevers()
        {
            return (Lever[])Levers.Clone();
        }

        public Level PushLever(Point playerPosition, int playerWidth, int playerHeight)
        {
            var playerRectangle = new Rectangle(playerPosition.X, playerPosition.Y, playerWidth, playerHeight);
            var isChanged = false;
            foreach(var lever in Levers)
            {
                var leverRectangle = new Rectangle(lever.Position.X, lever.Position.Y, lever.Width, lever.Height);
                if (leverRectangle.IntersectsWith(playerRectangle))
                {
                    if (Lands[lever.indexLandToChange] != Land.EmptyLand)
                    {
                        lever.savedLand = Lands[lever.indexLandToChange];
                        Lands[lever.indexLandToChange] = Land.EmptyLand;
                    }
                    else
                    {
                        Lands[lever.indexLandToChange] = lever.savedLand;
                        lever.savedLand = Land.EmptyLand;
                    }
                    isChanged = true;
                }
            }

            return isChanged ? this : EmptyLevel;
        }

        internal bool IsRightLandCollision(Point position, int width, int height)
        {
            var playerRectangle = new Rectangle(position.X, position.Y, width, height);
            foreach (var land in Lands)
            {
                if (land == Land.EmptyLand)
                    continue;

                if (position.X + width == land.Start.X)
                    return true;
            }                

            return false;
        }

        internal bool IsLeftLandCollision(Point position, int width, int height)
        {
            foreach (var land in Lands)
            {
                if (land == Land.EmptyLand)
                    continue;
                else if (position.X - width == land.Start.X)
                    return true;
            }

            return false;
        }
    }
}
