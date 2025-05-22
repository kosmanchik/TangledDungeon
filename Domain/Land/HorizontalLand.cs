using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace TangledDungeon.Domain
{
    public class HorizontalLand : ILand
    {
        public readonly Point Start;
        public readonly int Height;
        public readonly int Width;

        public HorizontalLand(Point start, int width, int height)
        {
            Start = start;
            Width = width;
            Height = height;
        }

        Point ILand.Start => Start;

        int ILand.Width => Width;

        int ILand.Height => Height;

        public bool IsOverlap(Point playerPosition, int playerWidth, int playerHeight)
        {
            if (this == ILand.EmptyLand)
                return false;

            var playerRectangle = new Rectangle(playerPosition.X, playerPosition.Y, playerWidth, playerHeight);
            var landRectangle = new Rectangle(Start.X, Start.Y, Width, Height);
            return landRectangle.IntersectsWith(playerRectangle) ? true : false;
        }
    }
}
