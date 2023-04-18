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
        public double X { get; set; }
        public double Y { get; set; }
        public int D { get; set; }
        public void Dispose();
    }
}
