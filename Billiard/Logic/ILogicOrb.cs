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
        public ILogicOrb createOrb(IOrb orb)
        {
            return new LogicOrb(orb);
        }
        public double X { get; set; }
        public double Y { get; set; }
        public int D { get; set; }
    }
}
