namespace DeckScaler
{
    public interface IRandomService : IService
    {
        T SelectRandom<T>(T[] collection);
    }

    public class RandomService : IRandomService
    {
        public T SelectRandom<T>(T[] collection)
        {
            var randomIndex = UnityEngine.Random.Range(0, collection.Length);
            return collection[randomIndex];
        }
    }
}