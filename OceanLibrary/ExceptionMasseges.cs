using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanLibrary
{
    public class ExceptionMasseges
    {
        public static string WrongeCoordinate(int numCols, int numRows, int MaxNumCols, int MaxNumRows)
        {

            return ($"The number of rows must be more than 0 and less than {MaxNumRows}. " +
                    $"The number of columns must be more than 0 and less than {MaxNumCols}." +
                    $"You passed the number of rows {numRows} and the number of columns {numCols}.");
        }
    }
}
