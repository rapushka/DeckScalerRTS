using System;
using UnityEngine;

namespace DeckScaler
{
    public abstract class BaseUnitView : MonoBehaviour
    {
        [SerializeField] private GameObject _root;

        public event Action ForceHideRequested;

        public abstract HpData HpData { get; }

        public abstract AutoAttackState AutoAttackState { get; }

        public abstract void OnAutoAttackButtonClick();

        public virtual void Show() => _root.SetActive(true);

        public virtual void Hide() => _root.SetActive(false);

        public abstract void UpdateValues();

        public abstract void Dispose();

        protected void ForceHide()
            => ForceHideRequested?.Invoke();
    }
}