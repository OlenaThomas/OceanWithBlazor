using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanLibrary
{
    public class Prey : Cell
    {
        #region --== const==--

        protected const int MAX_TIME_TO_REPRODUCE = 6;

        #endregion

        #region --== fields==--

        protected int _timeToReproduce;

        #endregion

        #region --==constructor==--

        public Prey(int row, int column, ICellContainer ocean) 
            : this(ocean, new Coordinate(row, column))
        {
            
        }

        public Prey(ICellContainer ocean, Coordinate place, int timeToReproduce = MAX_TIME_TO_REPRODUCE)
            : base(ocean, place)
        {
            _timeToReproduce = timeToReproduce;
        }

        #endregion

        #region --==methods==--

        /// <summary>
        /// Returns "f";
        /// </summary>
        public override CellViewType Image => CellViewType.Prey;

        /// <summary>
        /// Moves a cell to a randomly found adjacent empty cell;
        /// </summary>
        internal void MoveToEmptyCell()
        {
            IList<Coordinate> emptyCell = _owner.FindEmptyCell(_place);
            _timeToReproduce--;

            if (emptyCell.Count != 0)
            {
                int randomNumber = Randomizer.GetRandomToMove(0, emptyCell.Count);

                if (IsTimeToReproduce())                                         //???????????????????????????????
                {
                    _timeToReproduce = MAX_TIME_TO_REPRODUCE;
                    Reproduce(emptyCell[randomNumber]);
                }
                else
                {
                    _owner.MoveCell(_place, emptyCell[randomNumber]);
                    _place = emptyCell[randomNumber];        
                }
            }
        }

        /// <summary>
        /// Create a new Prey;
        /// </summary>
        /// <param name="emptyCell">Сell coordinates</param>
        protected virtual void Reproduce(Coordinate emptyCell)
        {
            Cell newCell = new Prey(emptyCell.Row, emptyCell.Column, this._owner); //TODO:IClonable???
            _owner.AddNewAnimal(newCell);
        }

        /// <summary>
        /// Moves to adjacent cell
        /// </summary>
        public override void Prosess()
        {
            MoveToEmptyCell();
        }

        /// <summary>
        /// Checks if it's time to reproduce
        /// </summary>
        /// <returns>bool</returns>
        protected bool IsTimeToReproduce() => _timeToReproduce == 0;

        #endregion
    }
}
