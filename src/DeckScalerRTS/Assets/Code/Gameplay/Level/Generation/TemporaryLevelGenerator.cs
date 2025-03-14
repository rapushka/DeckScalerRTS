namespace DeckScaler
{
    public interface ILevelGenerator : IService
    {
        LevelData GenerateLevel();
    }

    public class TemporaryLevelGenerator : ILevelGenerator
    {
        private readonly LevelData _data;

        public TemporaryLevelGenerator(LevelData data)
        {
            _data = data;
        }

        public LevelData GenerateLevel() => _data;
    }
}