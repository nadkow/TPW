using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public interface ILogicOrb : INotifyPropertyChanged
    {
        public double X { get;}
        public double Y { get;}
        public int D { get;}
        public void Dispose();
    }
}
