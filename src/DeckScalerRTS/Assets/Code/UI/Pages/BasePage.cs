using UnityEngine;

namespace DeckScaler
{
    public abstract class BasePage : MonoBehaviour
    {
        protected static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        public abstract void Initialize();

        public void Show()
        {
            transform.gameObject.SetActive(true);
        }

        public void Hide()
        {
            transform.gameObject.SetActive(false);
        }
    }
}