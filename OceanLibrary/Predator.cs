using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanLibrary
{
    public class Predator : Prey
    {
        #region --== const==--

        private const int MAX_TIME_TO_FEED = 6;

        #endregion

        #region --== fields==--

        private int _timeToFeed;

        #endregion

        #region --==constructor==--

        public Predator(int row, int column, ICellContainer ocean)
            : this(ocean, new Coordinate(row, column))
        {
            
        }

        public Predator(ICellContainer ocean, Coordinate place, int timeToFeed = MAX_TIME_TO_FEED)
            : base(ocean, place)
        {
            _timeToFeed = timeToFeed;
        }

        #endregion

        #region --==methods==--

        /// <summary>
        /// Moves to the prey's cell
        /// </summary>
        /// <param name="preyCoordinate">Prey coordinate</param>
        private void EatPrey(Coordinate preyCoordinate)
        {
            _owner.RemoveAnimal(preyCoordinate);  // for delegate

            _owner.MoveCell(_place, preyCoordinate);
            _place = preyCoordinate;
        }

        /// <summary>
        /// Create a new Predator;
        /// </summary>
        /// <param name="cell">Coordinate cell</param>
        protected override void Reproduce(Coordinate cell)                
        {
            Cell newCell = new Predator(cell.Row, cell.Column, this._owner);
            _owner.AddNewAnimal(newCell);               
        }

        /// <summary>
        /// If a prey is found, either move to the cell where the prey is located 
        /// or call the method Reproduce to create a new instance of the class in that cell. 
        /// If no prey is found and timeToFeed != 0 call the method MoveToEmptyCell. 
        /// If the prey is not found and timeToFeed == 0 deletes the object.
        /// </summary>
        public override void Prosess()
        {
            _timeToFeed--;
            IList<Cell> preys = GetPreys();

            if (preys.Count != 0)
            {
                int randomNumber = Randomizer.GetRandomToMove(0, preys.Count);
                _timeToFeed = MAX_TIME_TO_FEED;
                _timeToReproduce--;

                if (IsTimeToReproduce())
                {
                   _owner.RemoveAnimal(preys[randomNumber].Place);  // for delegate

                    Reproduce(preys[randomNumber].Place);
                    _timeToReproduce = MAX_TIME_TO_REPRODUCE;
                }
                else
                {
                    EatPrey(preys[randomNumber].Place);
                }                
            }
            else if (_timeToFeed == 0)
            {
                _owner.RemoveAnimal(_place);
            }
            else
            {
                MoveToEmptyCell();
            }
        }

        /// <summary>
        /// Removes from the list of neighbors all who are not prey
        /// </summary>
        /// <returns>Returns list of prey</returns>
        private IList<Cell> GetPreys()
        {
            IList<Cell> neighbors = _owner.FindNeighbors(_place);

            for (int i = 0; i < neighbors.Count; i++)
            {
                if (!(neighbors[i] is Prey && !(neighbors[i] is Predator)))   
                {
                    neighbors.RemoveAt(i);
                    i--;
                }
            }

            return neighbors;                             
        }

        /// <summary>
        /// Returns "S";
        /// </summary>
        public override CellViewType Image => CellViewType.Predator;

        #endregion
    }
}
