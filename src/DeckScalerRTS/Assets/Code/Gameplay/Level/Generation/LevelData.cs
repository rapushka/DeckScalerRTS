using System;
using System.Linq;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class LevelData
    {
        public LevelData() { }

        public LevelData(TentSpawnMarker[] tents, UnitSpawnMarker[] units, ShopSpawnMarker[] shops, ItemSpawnMarker[] items)
        {
            TentSpawns = tents.Select(m => new TentSpawnSetup(m)).ToArray();
            UnitSpawns = units.Select(m => new UnitSpawnSetup(m)).ToArray();
            ShopSpawns = shops.Select(m => new ShopSpawnSetup(m)).ToArray();
            ItemSpawns = items.Select(m => new ItemSpawnSetup(m)).ToArray();
        }

        [field: SerializeField] public TentSpawnSetup[] TentSpawns { get; private set; }
        [field: SerializeField] public UnitSpawnSetup[] UnitSpawns { get; private set; }
        [field: SerializeField] public ShopSpawnSetup[] ShopSpawns { get; private set; }
        [field: SerializeField] public ItemSpawnSetup[] ItemSpawns { get; private set; }
    }

    [Serializable]
    public class UnitSpawnSetup
    {
        public UnitSpawnSetup(UnitSpawnMarker spawnMarker)
        {
            UnitID = spawnMarker.UnitID;
            Side = spawnMarker.Side;
            SpawnPoint = spawnMarker.transform;
            TentIndex = spawnMarker.TentSpawn?.Index ?? -1;
        }

        [field: UnitID]
        [field: SerializeField] public string UnitID { get; private set; }

        [field: SerializeField] public Side      Side       { get; private set; }
        [field: SerializeField] public Transform SpawnPoint { get; private set; }

        [field: NaughtyAttributes.AllowNesting]
        [field: NaughtyAttributes.ShowIf(nameof(Side), Side.Enemy)]
        [field: SerializeField] public int TentIndex { get; private set; }
    }

    [Serializable]
    public class TentSpawnSetup
    {
        public TentSpawnSetup(TentSpawnMarker spawnMarker)
        {
            TentIndex = spawnMarker.Index;
            SpawnPoint = spawnMarker.transform;
        }

        [field: NaughtyAttributes.AllowNesting]
        [field: SerializeField] public int TentIndex { get; private set; }

        [field: SerializeField] public Transform SpawnPoint { get; private set; }
    }
}