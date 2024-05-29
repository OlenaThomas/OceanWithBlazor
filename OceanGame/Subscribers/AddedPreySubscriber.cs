using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanLibrary.Subscribers
{
    public class AddedPreySubscriber
    {
        public AddedPreySubscriber(Prey newPrey)
        {
            newPrey.AddedPreyOnSubscriber(ChangeNumberOfPrey);
        }

        public void ChangeNumberOfPrey()
        {

        }
    }
}
