using UnityEngine;

namespace DeckScaler
{
    [CreateAssetMenu(menuName = "375/DeckScaler/Item Config")]
    public class ItemConfig : ScriptableObject
    {
        [field: SerializeField] public ItemIDRef ID { get; private set; }

        [field: NaughtyAttributes.ShowAssetPreview]
        [field: SerializeField] public Sprite View { get; private set; }
    }
}