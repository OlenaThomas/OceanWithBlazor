using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanLibrary
{
    public interface ICellContainer : IOcean
    {
        bool IsCellEmpty(Coordinate coordinate);

        void AddNewAnimal(Cell newCell);

        void MoveCell(Coordinate oldCoord, Coordinate newCoord);

        void RemoveAnimal(Coordinate cell);

        IList<Coordinate> FindEmptyCell(Coordinate cellCoordinate);

        IList<Cell> FindNeighbors(Coordinate cell);
    }
}
