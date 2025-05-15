using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangledDungeon.Domain
{
    public class StaticEnemy
    {
        public readonly Point Position;
        public readonly int Width;
        public readonly int Height;

        public StaticEnemy(Point position, int width, int height)
        {
            Position = position;
            Width = width;
            Height = height;
        }
    }
}
