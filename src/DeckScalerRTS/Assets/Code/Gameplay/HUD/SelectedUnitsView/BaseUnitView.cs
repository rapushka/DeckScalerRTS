using UnityEngine;

namespace DeckScaler
{
    public abstract class BaseUnitView : MonoBehaviour
    {
        [SerializeField] private GameObject _root;

        public virtual void Show() => _root.SetActive(true);

        public virtual void Hide() => _root.SetActive(false);

        public virtual void Dispose() { } // TODO: when to dispose this shi????
    }
}