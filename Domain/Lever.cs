using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangledDungeon.Domain
{
    public class Lever
    {
        public readonly Point Position;
        public readonly int indexLandToChange;
        public readonly int Width;
        public readonly int Height;
        public Land savedLand { get; set; }

        public Lever(Point position, int index)
        {
            Position = position;
            indexLandToChange = index;
            Width = 30;
            Height = 36;
            savedLand = Land.EmptyLand;
        }
    }
}
