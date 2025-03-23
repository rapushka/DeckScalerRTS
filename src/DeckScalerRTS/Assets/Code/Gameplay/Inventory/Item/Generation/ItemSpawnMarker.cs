using UnityEngine;

namespace DeckScaler
{
    public class ItemSpawnMarker : MonoBehaviour
    {
        [field: ItemID]
        [field: SerializeField] public string ID { get; private set; }
    }
}