using Data;
using Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class ModelAbstractApi : INotifyPropertyChanged
    {
        public abstract event PropertyChangedEventHandler? PropertyChanged;

        public static ModelAbstractApi CreateApi()
        {  
            return new ModelApi();
        }

        public static ModelAbstractApi CreateApi(LogicAbstractApi? LogicApi)
        {
            return new ModelApi(LogicApi);
        }

        public abstract ObservableCollection<Circle> GetBalls();
        public abstract void Start(int noOfOrbs);
        public abstract void Stop();
    }
}
