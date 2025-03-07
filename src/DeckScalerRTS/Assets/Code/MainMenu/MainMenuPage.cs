using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
    public class MainMenuPage : BasePage
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _quitButton;

        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        public override void Initialize()
        {
            _playButton.onClick.AddListener(StartNewRun);
            _quitButton.onClick.AddListener(Quit);
        }

        private void StartNewRun()
        {
            UiMediator.ToGameState<GameplayGameState>();
        }

        private void Quit()
        {
            UiMediator.ToGameState<QuitGameState>();
        }
    }
}