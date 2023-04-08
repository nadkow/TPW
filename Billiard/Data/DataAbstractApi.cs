﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//w oddzielnej klasie definiujemy metody api (tu) a w innej je implementujemy (DataApi)
namespace Data
{
    public abstract class DataAbstractApi
    {
        public static DataAbstractApi CreateApi()
        {
            return new DataApi();
        }
        public abstract List<Orb> getOrbs();

        public abstract void Start(int tableWidth, int tableHeight, int numberOfOrbs);
        public abstract void Dispose();
    }
}
