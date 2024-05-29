using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OceanLibrary;

namespace OceanGame.Subscriber
{
    class SubscriberMovedCell
    {
        private int _offset;

        public SubscriberMovedCell(Ocean publisher, int offset)
        {
            publisher.MovedCell += MovedCellDelegate;
            _offset = offset;
        }

        private void MovedCellDelegate(object sender, MovedCellEventArgs args)
        {
            int x = args.NewCoord.Column;
            int y = args.NewCoord.Row;
           
            if (args.OldCell is Predator)
            {
                OceanConsoleVeiwer.ShowCell(x, y, CellViewType.Predator, _offset);
            }
            else if (args.OldCell is Prey && !(args.OldCell is Predator))
            {
                OceanConsoleVeiwer.ShowCell(x, y, CellViewType.Prey, _offset);
            }

            x = args.OldCell.Place.Column;
            y = args.OldCell.Place.Row;

            OceanConsoleVeiwer.ShowCell(x, y, CellViewType.Empty, _offset);
        }
    }
}
