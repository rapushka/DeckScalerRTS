using UnityEngine;

namespace DeckScaler
{
    public interface IGameConfig : IService
    {
        UnitsConfig     Units     { get; }
        LevelsConfig    Levels    { get; }
        UiConfig        UI        { get; }
        EconomyConfig   Economy   { get; }
        InventoryConfig Inventory { get; }
    }

    [CreateAssetMenu(menuName = "375/DeckScaler/GameConfig", order = -100)]
    public class GameConfig : ScriptableObject, IGameConfig
    {
        [field: NaughtyAttributes.BoxGroup(nameof(Units))]
        [field: SerializeField] public UnitsConfig Units { get; private set; }

        [field: NaughtyAttributes.BoxGroup(nameof(Levels))]
        [field: SerializeField] public LevelsConfig Levels { get; private set; }

        [field: NaughtyAttributes.BoxGroup(nameof(UI))]
        [field: SerializeField] public UiConfig UI { get; private set; }

        [field: NaughtyAttributes.BoxGroup(nameof(Economy))]
        [field: SerializeField] public EconomyConfig Economy { get; private set; }

        [field: NaughtyAttributes.BoxGroup(nameof(Inventory))]
        [field: SerializeField] public InventoryConfig Inventory { get; private set; }
    }
}