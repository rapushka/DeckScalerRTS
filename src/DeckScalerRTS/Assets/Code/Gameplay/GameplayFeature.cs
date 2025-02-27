namespace DeckScaler
{
    public sealed class GameplayFeature : Feature
    {
        public GameplayFeature()
        {
            Add(new TestSpawnUnitSystem());
        }
    }
}