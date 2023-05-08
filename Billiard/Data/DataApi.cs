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
            return new Orb(rnd.Next(5, tableWidth-5), rnd.Next(5, tableHeight-5)); 
        }

        public override void Dispose(IOrb orb)
        {
            orb.DisposeTimer();
        }
    }
}
