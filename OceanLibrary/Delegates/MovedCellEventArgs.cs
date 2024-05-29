using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanLibrary
{
    public class MovedCellEventArgs : EventArgs
    {
        public MovedCellEventArgs(Coordinate newCoord, Cell oldCell)
        {
            NewCoord = newCoord;
            OldCell = oldCell;
        }

        public Coordinate NewCoord { get; private set; }

        public Cell OldCell { get; private set; }
    }
}
