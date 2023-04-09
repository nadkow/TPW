using System.Collections.ObjectModel;
using Data;
using Logic;

namespace Model
{
    public class ModelApi : ModelAbstractApi
    {
        private LogicAbstractApi logicApi;
        private ObservableCollection<Circle> balls = new ObservableCollection<Circle>();

        public override ObservableCollection<Circle> GetBalls() { return balls; }

        public ModelApi()
        {
            this.logicApi = LogicAbstractApi.CreateApi();
            this.logicApi.PropertyChanged += OrbPosChanged;
        }

        private void GetCircles()
        {
            balls.Clear();
            foreach(Orb orb in this.logicApi.GetOrbs())
            {
                balls.Add(new Circle(orb));
            }
        }

        public override void Start(int noOfOrbs)
        {
            this.logicApi.Start(300-5, 400-5, noOfOrbs); // -5 bo promien kulki
            GetCircles();

        }

        public override void Stop()
        {
            this.logicApi.Dispose();
        }

        private void OrbPosChanged(object sender, EventArgs e)
        {
            // TODO tutaj dalej przesylanie pozycji orb
        }
    }
}