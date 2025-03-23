using System;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class ItemSpawnSetup
    {
        public ItemSpawnSetup(ItemSpawnMarker marker)
        {
            SpawnPoint = marker.transform;
            ID = marker.ID;
        }

        [field: SerializeField] public ItemIDRef ID         { get; private set; }
        [field: SerializeField] public Transform SpawnPoint { get; private set; }
    }
}