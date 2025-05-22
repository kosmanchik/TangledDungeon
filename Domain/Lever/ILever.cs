using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangledDungeon.Domain
{
    public interface ILever
    {
        public Point Position { get; }
        public int Width { get; }
        public int Height { get; }
        public LandCommand ChangeLevel(ILand[] lands);
    }
}
