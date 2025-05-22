using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangledDungeon.Domain
{
    public interface ILand
    {
        public static ILand? EmptyLand { get; }
        public Point Start { get; }
        public int Width { get; }
        public int Height { get; }

        public bool IsOverlap(Point overlapObjPosition, int overlapObjWidth, int overlapObjHeight);
    }
}
