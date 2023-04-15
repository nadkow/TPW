using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class DataApi : DataAbstractApi
    {
        public override IOrb CreateOrb(int tableWidth, int tableHeight)
        {
            Random rnd = new Random();
            return new Orb(rnd.Next(0, tableWidth), rnd.Next(0, tableHeight));
        }

        public override void Dispose(IOrb orb)
        {
            orb.DisposeTimer();
        }
    }
}
