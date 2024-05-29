using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanLibrary
{
    public interface IOcean
    {
        CellViewType this[int row, int column] { get; }
        int Height { get; }
        int Width { get; }
    }
}
