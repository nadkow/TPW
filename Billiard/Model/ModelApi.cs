using Logic;

namespace Model
{
    public class ModelApi : ModelAbstractApi
    {
        private LogicAbstractApi logicApi;

        public ModelApi()
        {
            this.logicApi = LogicAbstractApi.CreateApi();
            this.logicApi.PropertyChanged += OrbPosChanged;
        }

        public override void Start(int noOfOrbs)
        {
            this.logicApi.Start(300, 400, noOfOrbs); // nie wiem czy tutaj maja byc podane wymiary stolu
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