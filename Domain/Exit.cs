using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangledDungeon.Domain
{
    public class Exit
    {
        public readonly Point Position;

        public Exit(Point position)
        {
            Position = position;
        }
    }
}
