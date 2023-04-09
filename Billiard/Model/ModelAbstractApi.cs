using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class ModelAbstractApi
    {
        public static ModelAbstractApi CreateApi()
        {
            return new ModelApi();
        }
        public abstract ObservableCollection<Circle> GetBalls();
        public abstract void Start(int noOfOrbs);
        public abstract void Stop();
    }
}
