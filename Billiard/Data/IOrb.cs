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
        public double X { get;}
        public double Y { get;}
        public int D { get;}
        public void DisposeTimer();
    }
}
