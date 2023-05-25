using System.ComponentModel;

namespace ViewModel
{
    public interface IViewModelCircle : INotifyPropertyChanged
    {
        public double X { get; set; }
        public double Y { get; set; }
        public int D { get; set; }
    }
}
