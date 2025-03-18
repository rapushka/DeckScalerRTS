using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
    public class GameplayHUDPage : BasePage
    {
        [SerializeField] private Button _leaveGameButton;
        [SerializeField] private TMP_Text _moneyTextMesh;

        [field: SerializeField] public SelectedUnitsUiView SelectedUnitView { get; private set; }

        public int Money { set => _moneyTextMesh.text = $"${value}"; }

        public override void Initialize()
        {
            _leaveGameButton.onClick.AddListener(LeftRun);
        }

        private void LeftRun()
        {
            UiMediator.ToGameState<MainMenuGameState>();
        }
    }
}