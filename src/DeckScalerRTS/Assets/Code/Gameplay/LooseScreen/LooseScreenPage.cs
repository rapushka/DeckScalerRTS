using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
    public class LooseScreenPage : BasePage
    {
        [SerializeField] private Button _backToMainMenu;

        public override void Initialize()
        {
            _backToMainMenu.onClick.AddListener(BackToMainMenu);
        }

        private void BackToMainMenu()
        {
            UiMediator.ToGameState<MainMenuGameState>();
        }
    }
}