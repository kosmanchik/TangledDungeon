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
        private ILand[] Lands;
        private Exit LevelExit;
        private StaticEnemy[] StaticEnemies;
        private ILever[] Levers;
        public static Level EmptyLevel = new Level([], null, [], []);

        public Level(ILand[] lands, Exit levelExit, 
            StaticEnemy[] staticEnemies, ILever[] levers)
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

        public bool IsOnHorizontalLand(Point playerPosition, int playerWidth, int playerHeight)
        {
            foreach (var land in Lands.Where(land => land is HorizontalLand))
                if (land != ILand.EmptyLand 
                    && land.IsOverlap(playerPosition, playerWidth, playerHeight))
                    return true;
            return false;
        }

        public bool IsOnVerticalLand(Point playerPosition, int playerWidth, int playerHeight)
        {
            foreach (var land in Lands.Where(land => land is VerticalLand))
                if (land != ILand.EmptyLand 
                    && land.IsOverlap(playerPosition, playerWidth, playerHeight))
                    return true;
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

        public ILand[] GetLands()
        {
            return (ILand[])Lands.Clone();
        }

        public StaticEnemy[] GetStaticEnemies()
        {
            return (StaticEnemy[])StaticEnemies.Clone();
        }

        public ILever[] GetLevers()
        {
            return (ILever[])Levers.Clone();
        }

        public LandCommand PushLever(Point playerPosition, int playerWidth, int playerHeight)
        {
            var playerRectange = new Rectangle(playerPosition.X, playerPosition.Y, playerWidth, playerHeight);
            foreach(var lever in Levers)
            {
                var leverRectangle = new Rectangle(lever.Position.X, lever.Position.Y, lever.Width, lever.Height);
                if (leverRectangle.IntersectsWith(playerRectange))
                {
                    var landCommand = lever.ChangeLevel(Lands);
                    if (landCommand != LandCommand.EmptyCommand)
                        Lands[landCommand.Index] = landCommand.LandStatus;
                    return landCommand;
                }
            }

            return LandCommand.EmptyCommand;
        }
    }
}
