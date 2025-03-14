using System;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class LevelData
    {
        [field: NaughtyAttributes.BoxGroup("TMP")]
        [field: SerializeField] public TentSpawnSetupTMP[] TentSpawnsTMP { get; private set; }

        [field: NaughtyAttributes.BoxGroup("TMP")]
        [field: SerializeField] public UnitSpawnSetupTMP[] UnitSpawnsTMP { get; private set; }
    }

    [Serializable]
    public class UnitSpawnSetupTMP
    {
        [field: UnitID]
        [field: SerializeField] public string UnitID { get; private set; }

        [field: SerializeField] public Side      Side       { get; private set; }
        [field: SerializeField] public Transform SpawnPoint { get; private set; }

        [field: NaughtyAttributes.AllowNesting]
        [field: NaughtyAttributes.ShowIf(nameof(Side), Side.Enemy)]
        [field: SerializeField] public int TentIndex { get; private set; }
    }

    [Serializable]
    public class TentSpawnSetupTMP
    {
        [field: NaughtyAttributes.AllowNesting]
        [field: SerializeField] public int TentIndex { get; private set; }

        [field: SerializeField] public Transform SpawnPoint { get; private set; }
    }
}