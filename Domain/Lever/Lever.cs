using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace TangledDungeon.Domain
{
    public class Lever : ILever
    {
        public readonly Point Position;
        public readonly int Width;
        public readonly int Height;
        public ILand savedLand { get; set; }
        public int landIndexToRemove { get; set; }

        public Lever(Point position, int landToRemove)
        {
            Position = position;
            Width = 50;
            Height = 50;
            savedLand = ILand.EmptyLand;
            landIndexToRemove = landToRemove;
        }

        Point ILever.Position => Position;

        int ILever.Width => Width;

        int ILever.Height => Height;

        public LandCommand ChangeLevel(ILand[] lands)
        {
            if (savedLand == ILand.EmptyLand)
            {
                savedLand = lands[landIndexToRemove];
                return new LandCommand(ILand.EmptyLand, landIndexToRemove);
            }
            else
            {
                lands[landIndexToRemove] = savedLand;
                savedLand = ILand.EmptyLand;
                return new LandCommand(lands[landIndexToRemove], landIndexToRemove);
            }
        }
    }
}
