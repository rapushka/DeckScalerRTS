namespace DeckScaler
{
    public interface IIdentifiesService : IService
    {
        int Next();

        void Reset();
    }

    public class SimplestIdentifiesService : IIdentifiesService
    {
        private int _counter;

        public int Next() => _counter++;

        public void Reset() => _counter = 0;
    }
}