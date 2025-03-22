using UnityEngine;

namespace DeckScaler
{
    [CreateAssetMenu(menuName = "375/DeckScaler/Unit Config")]
    public class UnitConfig : ScriptableObject
    {
        [field: SerializeField] public UnitIDRef ID { get; private set; }

        [field: SerializeField] public bool IsLead { get; private set; }

        [field: NaughtyAttributes.BoxGroup("View")]
        [field: NaughtyAttributes.ShowAssetPreview]
        [field: SerializeField] public Sprite Head { get; private set; }

        [field: NaughtyAttributes.BoxGroup("View")]
        [field: NaughtyAttributes.ShowAssetPreview]
        [field: SerializeField] public Sprite Portrait { get; private set; }

        [field: NaughtyAttributes.BoxGroup("HP")]
        [field: SerializeField] public float MovementSpeed { get; private set; }

        [field: NaughtyAttributes.BoxGroup("HP")]
        [field: SerializeField] public float MaxHealth { get; private set; }

        [field: NaughtyAttributes.BoxGroup("Economy")]
        [field: SerializeField] public int Price { get; private set; }

        [field: NaughtyAttributes.BoxGroup("Attack & Abilities")]
        [field: SerializeField] public float Range { get; private set; }

        [field: NaughtyAttributes.BoxGroup("Attack & Abilities")]
        [field: SerializeField] public AbilityConfig[] Abilities { get; private set; }

        [field: NaughtyAttributes.BoxGroup("Inventory")]
        [field: SerializeField] public int InventorySlots { get; private set; }
    }
}