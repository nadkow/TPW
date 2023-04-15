using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Circle : INotifyPropertyChanged
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

        private void Update(object sender, PropertyChangedEventArgs e)
        {
                ILogicOrb orb = (ILogicOrb)sender;
                X = orb.X - 5;
                Y = orb.Y - 5;
                OnPropertyChanged(); //? nie wiem czy potrzebne
        }

        public double X { get => x; set { x = value; OnPropertyChanged(nameof(X)); } }
        public double Y { get => y; set { y = value; OnPropertyChanged(nameof(Y)); } }
        public int Diameter { get => diameter; set => diameter = value; }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
