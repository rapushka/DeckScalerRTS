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
        [SerializeField] private ShopSpawnMarker[] _shops;
        [SerializeField] private ItemSpawnMarker[] _items;

        public TentSpawnMarker[] Tents { set => _tents = value; }
        public UnitSpawnMarker[] Units { set => _units = value; }
        public ShopSpawnMarker[] Shops { set => _shops = value; }
        public ItemSpawnMarker[] Items { set => _items = value; }

        public LevelData GenerateLevel() => new(_tents, _units, _shops, _items);
    }
}