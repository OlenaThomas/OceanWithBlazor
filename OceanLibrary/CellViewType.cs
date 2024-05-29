using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanLibrary
{
    public enum CellViewType : ushort
    {
        Empty = 0x002D,
        Obstacle = 0x0023,
        Prey = 0x0066, 
        Predator = 0x0053
            // ...
    }
}
