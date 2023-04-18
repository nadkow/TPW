using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Logic;

namespace Model
{
    public interface ICircle : INotifyPropertyChanged
    {
        public double X { get; set; }
        public double Y { get; set; }
        public int D { get; set; }
    }
}
