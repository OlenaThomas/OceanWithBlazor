using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanLibrary
{
    public class Randomizer
    {
        static Random rand = new Random();           //?????????????????

        #region --==static methods==--

        /// <summary>
        /// Finds a random coordinate.
        /// </summary>
        /// <param name="numRows">Number of rows</param>
        /// <param name="numCols">Number of columns</param>
        /// <returns>Random coordinate</returns>
        public static Coordinate GetRandom(int numRows, int numCols)
        {
            int row = rand.Next(0, numRows);
            int column = rand.Next(0, numCols);
            Coordinate randomCoordinate = new Coordinate(row, column);   

            return randomCoordinate;
        }

        /// <summary>
        /// Finds a random number from a given range.
        /// </summary>
        /// <param name="rangeStart">range start</param>
        /// <param name="rangeEnd">range end</param>
        /// <returns>A random number from a given range</returns>
        internal static int GetRandomToMove(int rangeStart, int rangeEnd)
        {
            return rand.Next(rangeStart, rangeEnd);
        }

        #endregion
    }
}
