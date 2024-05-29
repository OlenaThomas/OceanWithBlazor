using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanLibrary
{
    public abstract class Cell    
    {
        #region --== fields==--

        protected readonly ICellContainer _owner;   
        protected Coordinate _place;

        #endregion

        #region --==constructor==--

        public Cell(ICellContainer ocean, Coordinate place)
        {
            _place = place;
            _owner = ocean;
        }

        #endregion

        #region --==properties==--

        public Coordinate Place
        {
            get
            {
                return _place;
            }
        }

        #endregion

        #region --==methods==--

        public virtual CellViewType Image => CellViewType.Empty;
       
        public abstract void Prosess();

        #endregion

    }
}
