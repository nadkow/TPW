using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public interface IViewModelCircle : INotifyPropertyChanged
    {
        public double X { get; set; }
        public double Y { get; set; }
        public int D { get; set; }
    }
}
