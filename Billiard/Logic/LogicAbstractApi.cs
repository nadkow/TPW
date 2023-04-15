using Data;
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

        public static LogicAbstractApi CreateApi(DataAbstractApi? DataApi)
        {
            return new LogicApi(DataApi);
        }

        public abstract List<Orb> GetOrbs();
        public abstract List<ILogicOrb> GetLogicOrbs();
        public abstract void Start(int width, int height, int noOfOrbs);
        public abstract void Dispose();
    }
}