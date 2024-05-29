using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OceanLibrary;
using OceanGame.Subscriber;

namespace OceanGame
{
    internal class Game
    {
        #region --== const==--

        private const int STANDARD_NUMBER_OF_ITERATIONS = 1000;

        #endregion

        #region --== fields==--

        private int _numOfIteration;
        private Ocean _ocean;
        SubscriberCountCell _subscriberCountCell;
        private int _offset;

        public int OceanHeight
        {
            get
            {
                return _ocean.Height;
            }
        }

        public int OceanOffset
        {
            get
            {
                return _offset;
            }
        }


        #endregion

        #region --==constructor==--

        internal Game(int offset)
        {
            _offset = offset;
            CreateOcean();

            bool resultNumOfIteration = UI.GetNumOfIteration(ref _numOfIteration, _offset);
            if (!resultNumOfIteration)
            {
                _numOfIteration = STANDARD_NUMBER_OF_ITERATIONS;
            }

            _subscriberCountCell = new SubscriberCountCell(_ocean, _offset);

            FillOutOcean();

            SubscriberChangedCell subscriberChangedCell = new SubscriberChangedCell(_ocean, _offset);

            SubscriberMovedCell subscriberMovedCell = new SubscriberMovedCell(_ocean, _offset);
        }
     
        #endregion

        #region --==methods==--

        private void CreateOcean()
        {
            int column = 0;
            int rows = 0;
            bool resultSizeOcean = UI.GetSizeOfOcean(ref rows, ref column, _offset);

            if (resultSizeOcean)
            {
                _ocean = new Ocean(column, rows);
            }
            else
            {
                _ocean = new Ocean();
            }
        }

        private void FillOutOcean()
        {
            int numPreys = 0;
            int numPredetors = 0;
            int numObstacles = 0;

            bool resultNumAnimals = UI.GetNumOfAnimals(ref numPreys, ref numPredetors, _offset);
            bool resultNumObstacles = false;

            if (resultNumAnimals)
            {
                resultNumObstacles = UI.GetNumOfObstacles(ref numObstacles, _offset);
            }

            OceanInitializer oceanInitializer = new OceanInitializer();

            if (resultNumAnimals && resultNumObstacles)
            {
                oceanInitializer.FillOcean(_ocean, numPreys, numPredetors, numObstacles);
            }
            else if (resultNumAnimals && !resultNumObstacles)
            {
                oceanInitializer.FillOcean(_ocean, numPreys, numPredetors);
            }
            else
            {
                oceanInitializer.FillOcean(_ocean);
            }
        }

        /// <summary>
        /// Calls the console veiwer to display the initial state of the game.
        /// </summary>
        internal void ShowInitialCondition()
        {
            int predator = _subscriberCountCell.PredatorCount;
            int prey = _subscriberCountCell.PreyCount;

            OceanConsoleVeiwer.Show(_ocean, _offset);
            OceanConsoleVeiwer.ShowResult(predator, prey, _offset, _ocean.Height);
            System.Threading.Thread.Sleep(3000);
        }

        /// <summary>
        /// Starts the game. The cycle continues until ContinueGame returns false.
        /// </summary>
        internal bool RunGame()
        {
            _ocean.Run();
            _numOfIteration--;
           
            return ContinueGame();
        }

        /// <summary>
        /// Checks to continue the game or not.
        /// </summary>
        /// <returns>bool</returns>
        private bool ContinueGame() => (_subscriberCountCell.PredatorCount != 0 
                && _subscriberCountCell.PreyCount != 0 && _numOfIteration != 0);

        #endregion
    }
}
