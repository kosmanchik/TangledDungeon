using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangledDungeon.Domain
{
    public class Level
    {
        private Land[] Lands;

        public Level(Land[] lands)
        {
            this.Lands = lands;
        }

        public bool IsOnLand(Point playerPosition, int playerWidth, int playerHeight)
        {
            foreach (var land in Lands)
            {
                if (playerPosition.X + playerWidth > land.Start.X && playerPosition.X < land.Start.X + land.Width &&
                    playerPosition.Y + playerHeight >= land.Start.Y && playerPosition.Y + playerHeight <= land.Start.Y + land.Height)
                    return true;
            }
            return false;
        }

        internal Land[] GetLands()
        {
            return (Land[])Lands.Clone();
        }
    }
}
