using UnityEngine;

namespace DeckScaler
{
    [CreateAssetMenu(menuName = "375/DeckScaler/Item Config")]
    public class ItemConfig : ScriptableObject
    {
        [field: SerializeField] public ItemIDRef ID { get; private set; }

        [field: NaughtyAttributes.ShowAssetPreview]
        [field: SerializeField] public Sprite Icon { get; private set; }

        [field: SerializeField] public bool IsDrink { get; private set; }

        [field: NaughtyAttributes.ShowIf(nameof(IsDrink))]
        [field: SerializeField] public AffectConfig DrinkAffect { get; private set; }
    }
}