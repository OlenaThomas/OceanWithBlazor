using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanLibrary
{
    public class ChangedCellEventArgs : EventArgs
    {
        public ChangedCellEventArgs(Cell target)
        {
            Target = target;
        }

        public Cell Target { get; private set; }
    }
}
