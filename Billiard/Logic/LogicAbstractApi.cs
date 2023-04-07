namespace Logic
{
    public abstract class LogicAbstractApi
    {
        public static LogicAbstractApi CreateApi()
        {
            return new LogicApi();
        }

        public abstract void Start(int width, int height, int noOfOrbs);
        public abstract void Dispose();
    }
}