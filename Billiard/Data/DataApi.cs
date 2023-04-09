using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class DataApi : DataAbstractApi
    {
        private readonly List<Orb> orbs = new List<Orb>();

        public override void Start(int tableWidth, int tableHeight, int numberOfOrbs)
        {
            Random rnd = new Random();
            for (int i = 0; i< numberOfOrbs; i++)
            {
                Orb newOrb = new Orb(rnd.Next(0, tableWidth), rnd.Next(0, tableHeight));
                orbs.Add(newOrb);
            }
        }

        public override void Dispose()
        {
            foreach(Orb orb in orbs)
            {
                orb.DisposeTimer();
            }
        }

        public override List<Orb> getOrbs()
        {
            return orbs;
        }
    }
}
