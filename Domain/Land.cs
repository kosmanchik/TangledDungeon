using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangledDungeon.Domain
{
    public class Land
    {
        public readonly Point Start;
        public readonly int Height;
        public readonly int Width;

        public Land(Point start, int width, int height)
        {
            Start = start;
            Width = width;
            Height = height;
        }
    }
}
