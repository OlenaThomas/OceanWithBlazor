using OceanLibrary;

namespace BlazorUIOcean.Subscriber
{
    public class SubscriberCountCell
    {
        private int _preyCount = 0;
        private int _predatorCount = 0;

        public SubscriberCountCell(Ocean publisher)
        {
            publisher.AddedCell += CountAddedCellDelegate;
            publisher.RemovedCell += CountRemovedCellDelegate;
        }

        public int PreyCount
        {
            get
            {
                return _preyCount;
            }
        }

        public int PredatorCount
        {
            get
            {
                return _predatorCount;
            }
        }

        private void CountAddedCellDelegate(object sender, ChangedCellEventArgs args)
        {
            if (args.Target is Predator)
            {
                _predatorCount++;
            }
            else if (args.Target is Prey && !(args.Target is Predator))
            {
                _preyCount++;
            }
        }
        private void CountRemovedCellDelegate(object sender, ChangedCellEventArgs args)
        {
            if (args.Target is Predator)
            {
                _predatorCount--;
            }
            else if (args.Target is Prey && !(args.Target is Predator))
            {
                _preyCount--;
            }
        }
    }
}
