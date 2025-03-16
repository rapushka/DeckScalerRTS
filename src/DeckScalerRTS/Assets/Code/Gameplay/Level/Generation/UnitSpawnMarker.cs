using UnityEngine;

namespace DeckScaler
{
    public class UnitSpawnMarker : MonoBehaviour
    {
        [field: UnitID]
        [field: SerializeField] public string UnitID { get; private set; }

        [field: SerializeField] public Side Side { get; private set; }

        [field: NaughtyAttributes.ShowIf(nameof(Side), Side.Enemy)]
        [field: SerializeField] public TentSpawnMarker TentSpawn { get; private set; }
    }
}