using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanLibrary
{
    public struct OceanAnalyzer
    {
        #region --== fields==--

        private int _numPreys;
        private int _numPredetors;

        #endregion

        #region --==properties==--
        public int NumPreys => _numPreys;

        public int NumPredetors => _numPredetors;

        #endregion

        #region --==methods==--

        /// <summary>
        /// Checks if there are preys in the ocean
        /// </summary>
        /// <returns>bool</returns>
        public bool ArePreysInOcean() => _numPreys > 0;

        /// <summary>
        /// Checks if there are predetors in the ocean
        /// </summary>
        /// <returns>bool</returns>
        public bool ArePredetorsInOcean() => _numPredetors > 0;

        /// <summary>
        /// Counts the number of predators and preys in ocean
        /// </summary>
        /// <param name="ocean">IOcean ocean</param>
        public void CulculateAnimals(IOcean ocean)
        {
            _numPreys = 0;
            _numPredetors = 0;

            for (int i = 0; i < ocean.Height; i++)
            {
                for (int j = 0; j < ocean.Width; j++)
                {
                    switch (ocean[i, j])
                    {
                        case CellViewType.Prey:
                            _numPreys++;
                            break;
                        case CellViewType.Predator:
                            _numPredetors++;
                            break;
                        case CellViewType.Empty:
                        default:
                            break;
                    }
                }
            }           
        }

        #endregion
    }
}
