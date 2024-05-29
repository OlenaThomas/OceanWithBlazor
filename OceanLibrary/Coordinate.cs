using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanLibrary
{
    public struct Coordinate
    {
        #region --== fields==--

        public int _row;
        public int _column;

        #endregion

        #region --==constructor==--

        public Coordinate(int row, int column)
        {
            _row = row;
            _column = column;
        }

        #endregion

        #region --==properties==--

        public int Row
        {
            get
            {
                return _row;
            }
            //set                    //TODO валидатор и исключения, в приватном методе
            //{
            //    _row = value;
            //}
        }

        public int Column
        {
            get
            {
                return _column;
            }
            //set
            //{
            //    _column = value;
            //}
        }

        #endregion
    }
}
