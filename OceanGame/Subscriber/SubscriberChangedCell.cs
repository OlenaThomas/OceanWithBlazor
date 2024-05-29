using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OceanLibrary;

namespace OceanGame.Subscriber
{
    class SubscriberChangedCell
    {
        private int _offset;

        public SubscriberChangedCell(Ocean publisher, int offset)
        {
            _offset = offset;
            publisher.AddedCell += AddedCellDelegate;
            publisher.RemovedCell += RemovedCellDelegate;
        }

        private void AddedCellDelegate(object sender, ChangedCellEventArgs args)
        {
            if (args.Target is Predator)
            {
                OceanConsoleVeiwer.ShowCell(args.Target.Place.Column, args.Target.Place.Row, CellViewType.Predator, _offset);
            }
            else if (args.Target is Prey && !(args.Target is Predator))
            {
                OceanConsoleVeiwer.ShowCell(args.Target.Place.Column, args.Target.Place.Row, CellViewType.Prey, _offset);
            }
        }

        private void RemovedCellDelegate(object sender, ChangedCellEventArgs args)
        {
            OceanConsoleVeiwer.ShowCell(args.Target.Place.Column, args.Target.Place.Row, CellViewType.Empty, _offset);
            
        }

    }
}
