using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OceanLibrary;

namespace OceanGame.Subscriber
{
    class SubscriberCountCell
    {
        private int _preyCount = 0;
        private int _predatorCount = 0;
        private int _offset;
        private int _oceanHeight;

        public SubscriberCountCell(Ocean publisher, int offset)
        {
            _oceanHeight = publisher.Height;
            _offset = offset;
            
            publisher.AddedCell += CountAddedCellDelegate;
            publisher.RemovedCell += CountRemovedCellDelegate;
            //publisher.CountAddedCell += DoCellDelegate;
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

            OceanConsoleVeiwer.ShowResult(_predatorCount, _preyCount, _offset, _oceanHeight);
        }

        //private void DoCellDelegate(object sender, EventArgs args)
        //{
            
        //}

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

            OceanConsoleVeiwer.ShowResult(_predatorCount, _preyCount, _offset, _oceanHeight);
        }
    }
}
