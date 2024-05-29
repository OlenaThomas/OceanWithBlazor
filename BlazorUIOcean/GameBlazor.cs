using BlazorUIOcean.Models;
using BlazorUIOcean.Subscriber;
using OceanLibrary;
using System.Data.Common;

namespace BlazorUIOcean
{
    public class GameBlazor
    {
        #region --== const==--

        public const int STANDARD_NUMBER_OF_ITERATIONS = 1000;

        #endregion

        #region --== fields==--

        private int _numOfIteration;
        private Ocean _ocean;
        SubscriberCountCell _subscriberCountCell;

        #endregion

        #region --==constructor==--

        public GameBlazor()
        {

        }
        internal GameBlazor(GameParameters GameParameters)
        {
            _ocean = new Ocean(GameParameters.OceanWidth, GameParameters.OceanHeight);
            _subscriberCountCell = new SubscriberCountCell(_ocean);

            OceanInitializer oceanInitializer = new OceanInitializer();
            oceanInitializer.FillOcean(_ocean, GameParameters.NumberOfPreys, GameParameters.NumberOfPredetors, GameParameters.NumberOfObstacles);
        }

        #endregion

        #region --==methods==--

        internal Ocean GetOcean() => _ocean;
        internal int GetCountOfPredators() => _subscriberCountCell.PredatorCount;
        internal int GetCountOfPreys() => _subscriberCountCell.PreyCount;


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
