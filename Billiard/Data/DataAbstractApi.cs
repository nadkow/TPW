using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class DataAbstractApi
    {
        public static DataAbstractApi CreateApi()
        {
            return new DataApi();
        }

        public abstract IOrb CreateOrb(int tableWidth, int tableHeight);
        public abstract void Start(int tableWidth, int tableHeight);
    }
}
