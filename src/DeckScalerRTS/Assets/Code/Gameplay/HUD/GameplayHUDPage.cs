using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
    public class GameplayHUDPage : BasePage
    {
        [SerializeField] private Button _leaveGameButton;

        [field: SerializeField] public SelectedUnitsUiView SelectedUnitView { get; private set; }

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