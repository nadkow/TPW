using System.ComponentModel;

namespace Logic
{
    public abstract class LogicAbstractApi : INotifyPropertyChanged
    {
        public abstract event PropertyChangedEventHandler? PropertyChanged;

        public static LogicAbstractApi CreateApi()
        {
            return new LogicApi();
        }

        public abstract void Start(int width, int height, int noOfOrbs);
        public abstract void Dispose();
    }
}