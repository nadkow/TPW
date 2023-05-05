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
        public double XSpeed { get;}
        public double YSpeed { get;}
        public void SetSpeed(double x, double y);
        public void Start();
        public void DisposeTimer();
        public void Collision();
        public void CollisionBorder(String axis);
    }
}
