using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Logic;

namespace Model
{
    internal class ModelApi : ModelAbstractApi
    {
        private LogicAbstractApi logicApi;
        private ObservableCollection<ICircle> balls = new ObservableCollection<ICircle>();
        public override event PropertyChangedEventHandler? PropertyChanged;

        public override ObservableCollection<ICircle> GetBalls() { return balls; }

        public ModelApi(LogicAbstractApi api = null)
        {
            if (api != null) { logicApi = api; }
            else { logicApi = LogicAbstractApi.CreateApi(); }
        }

        private void GetCircles()
        {
            balls.Clear();
            foreach(ILogicOrb orb in this.logicApi.GetLogicOrbs())
            {
                ICircle circle = new Circle(orb);
                balls.Add(circle);
            }
        }

        public override void Start(int noOfOrbs)
        {
            this.logicApi.Start(290, 390, noOfOrbs); // -5 bo promien kulki
            GetCircles();

        }

        public override void Stop()
        {
            this.logicApi.Dispose();
        }

        private void OrbPosChanged(object sender, PropertyChangedEventArgs e)
        {
                OnPropertyChanged();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}