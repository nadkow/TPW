using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class DataApi : DataAbstractApi
    {
        private static Random rnd = new Random();
        private FileWriter fw = new FileWriter();

        public DataApi()
        {
        }

        public override IOrb CreateOrb(int tableWidth, int tableHeight)
        {
            IOrb orb = new Orb(rnd.Next(5, tableWidth - 5), rnd.Next(5, tableHeight - 5));
            orb.PropertyChanged += fw.EnqueuePos;
            return orb;
        }

        public override void Start(int tableWidth, int tableHeight, int noOfOrbs)
        {
            fw.Start(tableWidth, tableHeight, noOfOrbs);
        }
    }
}
