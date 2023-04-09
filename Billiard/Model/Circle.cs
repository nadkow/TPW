using Data;
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
        private int x;
        private int y;
        private int diameter;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Circle(Orb orb)
        {
            x = orb.X;
            y = orb.Y;
            diameter = orb.D;
            orb.PropertyChanged += Update;
        }

        private void Update(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Position")
            {
                Orb orb = (Orb)sender;
                X = orb.X;
                Y = orb.Y;
            }
        }

        public int X { get => x; set { x = value; OnPropertyChanged(nameof(X)); } }
        public int Y { get => y; set { y = value; OnPropertyChanged(nameof(Y)); } }
        public int Diameter { get => diameter; set => diameter = value; }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
