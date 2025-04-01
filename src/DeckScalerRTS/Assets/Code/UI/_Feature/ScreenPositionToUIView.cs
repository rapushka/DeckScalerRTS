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
            _target.anchoredPosition = positionOnCanvas;
        }
    }
}