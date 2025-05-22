using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangledDungeon.Domain
{
    public class LandCommand
    {
        public ILand LandStatus { get; set; }
        public int Index { get; set; }
        public static LandCommand EmptyCommand = new LandCommand(ILand.EmptyLand, int.MaxValue);

        public LandCommand(ILand land, int index)
        {
            LandStatus = land;
            Index = index;
        }
    }
}
