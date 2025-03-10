using UnityEngine;

namespace DeckScaler
{
    public abstract class BaseUnitView : MonoBehaviour
    {
        [SerializeField] private GameObject _root;

        public abstract float  HealthPercent { get; }
        public abstract string HealthText    { get; }

        public abstract AutoAttackState AutoAttackState { get; }

        public abstract void OnAutoAttackButtonClick();

        public virtual void Show() => _root.SetActive(true);

        public virtual void Hide() => _root.SetActive(false);

        public abstract void Dispose();
    }
}