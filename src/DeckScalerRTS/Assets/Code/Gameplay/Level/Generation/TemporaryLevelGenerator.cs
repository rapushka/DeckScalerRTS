using System;
using UnityEngine;

namespace DeckScaler
{
    public interface ILevelGenerator : IService
    {
        LevelData GenerateLevel();
    }

    [Serializable]
    public class TemporaryLevelGenerator : ILevelGenerator
    {
        [SerializeField] private TentSpawnMarker[] _tents;
        [SerializeField] private UnitSpawnMarker[] _units;

        public TentSpawnMarker[] Tents { set => _tents = value; }
        public UnitSpawnMarker[] Units { set => _units = value; }

        public LevelData GenerateLevel() => new(_tents, _units);
    }
}