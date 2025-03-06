using UnityEngine;

namespace DeckScaler
{
    public abstract class BasePage : MonoBehaviour
    {
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