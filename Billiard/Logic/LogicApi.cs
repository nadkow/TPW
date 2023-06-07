using System.ComponentModel;
using System.Runtime.CompilerServices;
using Data;

namespace Logic
{
    internal class LogicApi : LogicAbstractApi
    {
        Semaphore semaphoreOrb = new Semaphore(1, 1);
        Semaphore semaphoreBorder = new Semaphore(1, 1);
        private DataAbstractApi dataApi;
        private int width;
        private int height;
        private readonly List<ILogicOrb> logicOrbs = new List<ILogicOrb>();

        public override event PropertyChangedEventHandler? PropertyChanged;

        public LogicApi(DataAbstractApi api = null)
        {
            if (api != null) { dataApi = api; }
            else { dataApi = DataAbstractApi.CreateApi(); }
        }

        public override List<ILogicOrb> GetLogicOrbs()
        {
            return logicOrbs;
        }

        public override void Start(int width, int height, int noOfOrbs)
        {
            this.width = width;
            this.height = height;
            for (int i = 0; i < noOfOrbs; i++)
            {
                IOrb newOrb = dataApi.CreateOrb(width, height);
                ILogicOrb newLogicOrb = new LogicOrb(newOrb);
                logicOrbs.Add(newLogicOrb);

            }
            foreach (ILogicOrb orb in logicOrbs)
            {
                orb.PropertyChanged += OrbPosChanged;
            }
            dataApi.Start(width, height, noOfOrbs);
            // laczymy event dopiero w metodzie Start, a nie w konstruktorze, bo wtedy orby jeszcze nie istnieja
        }

        public override void Dispose()
        {
            foreach (ILogicOrb orb in logicOrbs)
            {
                orb.Dispose();
            }
            logicOrbs.Clear();

        }

        private void OrbPosChanged(ILogicOrb orb, double x, double y)
        {
            semaphoreOrb.WaitOne();
            CheckCollisionWithOrbs(orb, x, y);
            semaphoreOrb.Release(1);
            semaphoreBorder.WaitOne();
            CheckCollisionWithBorder(orb, x, y);
            semaphoreBorder.Release(1);
        }

        private void CheckCollisionWithOrbs(ILogicOrb orb, double x, double y)
        {
            double otherX, otherY;
            foreach (var oneOfOrbs in logicOrbs)
            {
                if (oneOfOrbs != orb)
                {
                    lock (oneOfOrbs.CoordsLock)
                    {
                        otherX = oneOfOrbs.Coords.x;
                        otherY = oneOfOrbs.Coords.y;
                    }
                    double distance = Math.Sqrt(Math.Pow(x - otherX, 2) + Math.Pow(y - otherY, 2));
                    if (distance <= 10)
                    {
                        Vector speed = orb.Speed;
                        Vector otherSpeed = oneOfOrbs.Speed;
                        if ((speed.x - otherSpeed.x)*(otherX - x) + (speed.y - otherSpeed.y)*(otherY - y) >= 0)
                        {
                            double xs = speed.x;
                            double xy = speed.y;
                            orb.SetSpeed(otherSpeed.x, otherSpeed.y);
                            oneOfOrbs.SetSpeed(xs, xy);
                        }
                    }
                }
            }
        }

        private void CheckCollisionWithBorder(ILogicOrb orb, double x, double y)
        {
            Vector speed;
            lock(orb.SpeedLock)
            {
                speed = orb.Speed;
            }
            if (y >= height - 5)
            {
                if (speed.y > 0)
                    orb.CollisionBorderY();
            }
            else if(y <= 5)
            {
                if (speed.y < 0)
                    orb.CollisionBorderY();
            }
            else if (x >= width - 5)
            {
                if (speed.x > 0)
                    orb.CollisionBorderX();
            }
            else if (x <= 5)
            {
                if (speed.x < 0)
                    orb.CollisionBorderX();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            // ta metoda na razie nie jest wywolywana ale zostawiamy do uzycia w przyszlosci
        }
    }
}
