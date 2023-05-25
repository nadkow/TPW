using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model;

namespace ViewModel
{
    internal class ViewModelCircle : IViewModelCircle
    {
        private double x;
        private double y;
        private int diameter;

        public event PropertyChangedEventHandler? PropertyChanged;

        public double X { get => x; set { x = value; OnPropertyChanged(nameof(X)); } }
        public double Y { get => y; set { y = value; OnPropertyChanged(nameof(Y)); } }
        public int D { get => diameter; set => diameter = value; }
        public ViewModelCircle(ICircle circle) {
            x = circle.X - 5;
            y = circle.Y - 5;
            diameter = circle.D;
            circle.PropertyChanged += Update;
        }

        private void Update(double x, double y)
        {
            X = x - 5;
            Y = y - 5;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
