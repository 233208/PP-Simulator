using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class BigTorusMap : BigMap
    {
        public BigTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            FNext = MoveRules.WallNext;
            FNextDiagonal = MoveRules.WallNextDiagonal;
        }

    }
}
