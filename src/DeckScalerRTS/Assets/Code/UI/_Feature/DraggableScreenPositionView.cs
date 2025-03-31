using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class DraggableScreenPositionView
        : BaseListener<UiScope>,
          IRegistrableListener<UiScope, Dragging>,
          IRegistrableListener<UiScope, ScreenPosition>
    {
        [SerializeField] private RectTransform _parent;
        [SerializeField] private RectTransform _target;

        private Entity<UiScope> _entity;

        public override void Register(Entity<UiScope> entity)
        {
            _entity = entity;
            _entity.Retain(this);

            _entity.AddListener<Dragging>(this);
            _entity.AddListener<ScreenPosition>(this);

            if (_entity.Has<ScreenPosition>())
                UpdateValue(_entity);
        }

        public override void Unregister()
        {
            _entity.RemoveListener<Dragging>(this);
            _entity.RemoveListener<ScreenPosition>(this);

            _entity.Release(this);
            _entity = null;
        }

        public void OnValueChanged(Entity<UiScope> entity, ScreenPosition component) => UpdateValue(entity);

        public void OnValueChanged(Entity<UiScope> entity, Dragging component) => UpdateValue(entity);

        private void UpdateValue(Entity<UiScope> entity)
        {
            if (!_entity.Is<Dragging>())
            {
                _target.SetupToParent(_parent);
                return;
            }

            _target.anchoredPosition = entity.Get<ScreenPosition, Vector2>();
        }
    }
}