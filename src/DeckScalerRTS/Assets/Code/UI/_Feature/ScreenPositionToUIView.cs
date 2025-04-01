using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class ScreenPositionToUIView : BaseListener<UiScope, ScreenPosition>
    {
        [SerializeField] private RectTransform _target;
        private RectTransform _parent;

        private static IUiService UI => ServiceLocator.Resolve<IUiService>();

        public override void OnValueChanged(Entity<UiScope> entity, ScreenPosition component)
        {
            _parent ??= (RectTransform)_target.parent;

            var screenPosition = component.Value;
            var positionOnCanvas = UI.GetPositionOnCanvas(screenPosition, _parent);

            var pivotOffset = new Vector2(
                _target.pivot.x * _target.rect.width,
                _target.pivot.y * _target.rect.height
            );
            // pivotOffset = Vector2.zero;

            _target.anchoredPosition = positionOnCanvas - pivotOffset;
        }
    }
}