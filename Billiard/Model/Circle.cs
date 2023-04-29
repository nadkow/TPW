using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class Circle : ICircle
    {
        // wizualna reprezentacja Orb
        private double x;
        private double y;
        private int diameter;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Circle(ILogicOrb orb)
        {
            diameter = orb.D;
            x = orb.X - 5;
            y = orb.Y - 5; 
            orb.PropertyChanged += Update;

        }
        public double X { get => x;}
        public double Y { get => y;}
        public int D { get => diameter;}

        private void Update(object sender, PropertyChangedEventArgs e)
        {
            ILogicOrb orb = (ILogicOrb)sender;
            x = orb.X - 5;
            y = orb.Y - 5;
            OnPropertyChanged();
        }

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
