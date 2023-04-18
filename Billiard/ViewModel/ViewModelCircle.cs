using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Data;
using Model;

namespace ViewModel
{
    internal class ViewModelCircle :IViewModelCircle
    {
        private double x;
        private double y;
        private int diameter;

        public event PropertyChangedEventHandler? PropertyChanged;

        public double X { get => x; set { x = value; OnPropertyChanged(nameof(X)); } }
        public double Y { get => y; set { y = value; OnPropertyChanged(nameof(Y)); } }
        public int D { get => diameter; set => diameter = value; }
        public ViewModelCircle(ICircle circle) {
            x = circle.X;
            y = circle.Y;
            diameter = circle.D;
            circle.PropertyChanged += Update;
        }

        private void Update(object sender, PropertyChangedEventArgs e)
        {
            ICircle circle = (ICircle)sender;
            X = circle.X;
            Y = circle.Y;
            OnPropertyChanged();
        }

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
