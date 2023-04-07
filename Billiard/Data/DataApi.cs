using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class DataApi : DataAbstractApi
    {
        public override void Start(int numberOfOrbs)
        {
            Random rnd = new Random();
            for (int i = 0; i< numberOfOrbs; i++)
            {
                Orb newOrb = new Orb(rnd.Next(-100,100), rnd.Next(-100,100)); //TODO wartosci do zmiany po ustaleniu wielkosci stolu
            }
        }
    }
}
