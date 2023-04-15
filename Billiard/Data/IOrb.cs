using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IOrb : INotifyPropertyChanged
    {
        public IOrb createOrb(double x,double y)
        {
            return new Orb(x,y);
        }

        public double X { get; set; }
        public double Y { get; set; }
        public int D { get; set; }
        public void DisposeTimer();
    }
}
