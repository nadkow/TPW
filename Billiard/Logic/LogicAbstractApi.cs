namespace Logic
{
    public abstract class LogicAbstractApi
    {
        public static LogicAbstractApi CreateApi()
        {
            return new LogicApi();
        }

        public abstract void Start();
    }
}