using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
    public class GameplayPage : BasePage
    {
        [SerializeField] private Button _leaveGameButton;

        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        public override void Initialize()
        {
            _leaveGameButton.onClick.AddListener(LeftGame);
        }

        private void LeftGame()
        {
            UiMediator.ToGameState<MainMenuGameState>();
        }
    }
}