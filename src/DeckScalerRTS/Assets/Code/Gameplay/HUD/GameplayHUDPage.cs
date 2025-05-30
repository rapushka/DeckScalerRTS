using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
    public class GameplayHUDPage : BasePage
    {
        [SerializeField] private Button _leaveGameButton;
        [SerializeField] private TMP_Text _moneyTextMesh;
        [SerializeField] private TimeManipulationUI _timeUI;

        [field: SerializeField] public SelectedUnitsUiView SelectedUnitView { get; private set; }
        [field: SerializeField] public InventoryUI         Inventory        { get; private set; }

        public int Money { set => _moneyTextMesh.text = $"${value}"; }

        public override void Initialize()
        {
            _leaveGameButton.onClick.AddListener(LeftRun);
            _timeUI.Initialize();
        }

        private void LeftRun()
        {
            UiMediator.ToGameState<MainMenuGameState>();
        }
    }
}