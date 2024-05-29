using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanLibrary
{
    public class OceanInitializer
    {
        public const int MAX_NUM_PREYS = 5;
        public const int MAX_NUM_PREDETORS = 2;
        public const int MAX_NUM_OBSTACLES = 5;
        //int _numPrey = 150;
        //int _numPredetors = 20;
        //int _numObstacles = 75;

        #region --==constructor==--

        public void FillOcean(ICellContainer ocean, int numPrey = MAX_NUM_PREYS, 
                int numPredetors = MAX_NUM_PREDETORS, int numObstacles = MAX_NUM_OBSTACLES)
        {
            PutPreyInOcean(ocean, numPrey);
            PutPredatorInOcean(ocean, numPredetors);
            PutObstacleInOcean(ocean, numObstacles);
        }

        #endregion

        #region --==methods==--

        /// <summary>
        /// Finds a randomly adjacent empty coordinate.
        /// </summary>
        /// <param name="ocean">ICellContainer ocean</param>
        /// <returns>A randomly adjacent empty coordinate</returns>
        private Coordinate GetRandomEmptyCell(ICellContainer ocean)
        {
            bool result = true;
            Coordinate randomCoord = new Coordinate();

            while (result)
            {
                randomCoord = Randomizer.GetRandom(ocean.Height, ocean.Width);

                if (ocean.IsCellEmpty(randomCoord))
                {
                    result = false;
                }
            }

            return randomCoord;
        }

        /// <summary>
        /// Adds a given amount of preys to the ocean.
        /// </summary>
        /// <param name="ocean">ICellContainer ocean</param>
        /// <param name="numPrey">number of prey</param>
        private void PutPreyInOcean(ICellContainer ocean, int numPrey)
        {
            int counter = numPrey;

            while (counter > 0)
            {
                Coordinate newCoord = GetRandomEmptyCell(ocean);
                Prey newPrey = new Prey(ocean, newCoord);
                ocean.AddNewAnimal(newPrey);

                counter--;
            }
        }

        /// <summary>
        /// Adds a given amount of predetors to the ocean.
        /// </summary>
        /// <param name="ocean">ICellContainer ocean</param>
        /// <param name="numPrey">number of predetors</param>
        private void PutPredatorInOcean(ICellContainer ocean, int numPredetors)
        {
            int counter = numPredetors;

            while (counter > 0)
            {
                Coordinate newCoord = GetRandomEmptyCell(ocean);
                Predator newPredator = new Predator(ocean, newCoord);
                ocean.AddNewAnimal(newPredator);

                counter--;
            }
        }

        /// <summary>
        /// Adds a given amount of obstacles to the ocean.
        /// </summary>
        /// <param name="ocean">ICellContainer ocean</param>
        /// <param name="numPrey">number of obstacles</param>
        private void PutObstacleInOcean(ICellContainer ocean, int numObstacles)
        {
            int counter = numObstacles;

            while (counter > 0)
            {
                Coordinate newCoord = GetRandomEmptyCell(ocean);
                Obstacle newObstacle = new Obstacle(ocean, newCoord);
                ocean.AddNewAnimal(newObstacle);

                counter--;
            }
        }

        #endregion
    }
}
