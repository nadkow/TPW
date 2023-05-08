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
        public int M { get; }
        public double XSpeed { get;}
        public double YSpeed { get;}
        public void SetSpeed(double x, double y);
        public Task Start();
        public void DisposeTimer();
        public void Collision(IOrb orb); //przekazujemy orba z ktorym sie zderzyl
        public void CollisionBorderX();
        public void CollisionBorderY();
        public void ChangeRoute(double xv, double yv);
    }
}
