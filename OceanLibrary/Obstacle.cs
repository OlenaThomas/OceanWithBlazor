using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanLibrary
{
    public class Obstacle : Cell 
    {
        #region --==constructor==--

        public Obstacle(ICellContainer ocean, Coordinate place)
            : base(ocean, place)
        {
            
        }

        public override void Prosess()
        {
            
        }

        public override CellViewType Image => CellViewType.Obstacle;

        #endregion

    }
}
