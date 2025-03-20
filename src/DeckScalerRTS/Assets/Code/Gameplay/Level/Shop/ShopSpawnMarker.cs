using System;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class ShopSpawnSetup
    {
        public ShopSpawnSetup(ShopSpawnMarker marker)
        {
            SpawnPoint = marker.transform;
        }

        [field: SerializeField] public Transform SpawnPoint { get; private set; }
    }

    public class ShopSpawnMarker : MonoBehaviour { }
}