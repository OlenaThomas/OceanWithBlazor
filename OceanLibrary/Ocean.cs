using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OceanLibrary.Delegates;

namespace OceanLibrary
{
    public class Ocean : IOcean, ICellContainer
    {
        public const int MAX_NUM_COLS = 7;
        public const int MAX_NUM_ROWS = 5;
       
        private int _numCols; //x 0-69
        private int _numRows; //y 0-24
        private Cell[,] _cells;

        #region --===delegate===--

        private ChangedCellDelegate _addedCell;
        private ChangedCellDelegate _removedCell;
        private MovedCellDelegate _movedCell;

        #endregion

        #region --===event delegate===--

        public event ChangedCellDelegate AddedCell
        {
            add
            {
                _addedCell += value;
            }
            remove
            {
                _addedCell -= value;
            }
        }

        public event ChangedCellDelegate RemovedCell
        {
            add
            {
                _removedCell += value;
            }
            remove
            {
                _removedCell -= value;
            }
        }

        public event MovedCellDelegate MovedCell
        {
            add
            {
                _movedCell += value;
            }
            remove
            {
                _movedCell -= value;
            }
        }

        #endregion

        #region --  IOcean  ---

        public int Height => _numRows;

        public int Width => _numCols;

        //public int MaxNumCols => MAX_NUM_COLS;

        //public int MaxNumRows => MAX_NUM_ROWS;

        public CellViewType this[int row, int column]
        {
            get
            {
                if(_cells[row, column] == null)
                {
                    return CellViewType.Empty;
                }
                
                return _cells[row, column].Image;
            }
        }

        public bool IsCellEmpty(Coordinate coordinate)
        {
            return _cells[coordinate.Row, coordinate.Column] == null;
        }

        #endregion

        //public Ocean(int numCols = 70, int numRows = 25)
        public Ocean(int numCols = MAX_NUM_COLS, int numRows = MAX_NUM_ROWS)  
        {
            _numCols = numCols;
            _numRows = numRows;
            _cells = new Cell[ numRows, numCols];
        }
              
        public void Run()
        {
            for (int i = 0; i < _numRows; i++)
            {
                for (int j = 0; j < _numCols; j++)
                {
                    if (_cells[i, j] != null)
                    {
                        _cells[i, j].Prosess();
                    }
                }
            }
        }
        
        public void MoveCell(Coordinate oldCoord, Coordinate newCoord)
        {
            _movedCell?.Invoke(this, new MovedCellEventArgs(newCoord, _cells[oldCoord.Row, oldCoord.Column]));
            
            _cells[newCoord.Row, newCoord.Column] = _cells[oldCoord.Row, oldCoord.Column];

            _cells[oldCoord.Row, oldCoord.Column] = null;
        }

        public void AddNewAnimal(Cell newCell)
        {
            if (!IsValidCoordinate(newCell.Place))
            {
                string message = ExceptionMasseges.WrongeCoordinate(newCell.Place.Column, newCell.Place.Row, MAX_NUM_COLS, MAX_NUM_ROWS);
                throw new WrongCoordinateException(message, newCell.Place);
            }

            _cells[newCell.Place.Row, newCell.Place.Column] = newCell;
                        
            _addedCell?.Invoke(this, new ChangedCellEventArgs(newCell));
        }

        public void RemoveAnimal(Coordinate cell)  
        {
            _removedCell?.Invoke(this, new ChangedCellEventArgs(_cells[cell.Row, cell.Column]));
                       
            _cells[cell.Row, cell.Column] = null;
        }

        public List<Coordinate> FindAvailableCoordinates(Coordinate cell)
        {
            List<Coordinate> availableCoordinates = new List<Coordinate>
            {
                new Coordinate(cell.Row, cell.Column - 1),
                new Coordinate(cell.Row, cell.Column + 1),
                new Coordinate(cell.Row - 1, cell.Column),
                new Coordinate(cell.Row + 1, cell.Column)
            };

            for (int i = 0; i< availableCoordinates.Count; i++)
            {
                if (!IsValidCoordinate(availableCoordinates[i]))  
                {
                    availableCoordinates.RemoveAt(i);
                    i--;
                }
            }

            return availableCoordinates;
        }

        private bool IsValidCoordinate(Coordinate checkCoord)
        {
            return (checkCoord.Row >= 0) && (checkCoord.Row < _numRows) 
                    && (checkCoord.Column >= 0) && (checkCoord.Column < _numCols);
        }

        public IList<Cell> FindNeighbors(Coordinate cell)
        {
            List<Coordinate> available = FindAvailableCoordinates(cell);
            List<Cell> neighbors = new List<Cell>();

            for (int i = 0; i< available.Count; i++)
            {
                if(_cells[available[i].Row, available[i].Column] != null)
                {
                    neighbors.Add(_cells[available[i].Row, available[i].Column]);
                }
            }
                        
            return neighbors;
        }

        public IList<Coordinate> FindEmptyCell(Coordinate cellCoordinate)
        {
            List<Coordinate> available = FindAvailableCoordinates(cellCoordinate);
            
            for (int i = 0; i < available.Count; i++)
            {
                if (_cells[available[i].Row, available[i].Column] != null)
                {
                    available.RemoveAt(i);
                    i--;
                }
            }

            return available;
        }
    }
}
