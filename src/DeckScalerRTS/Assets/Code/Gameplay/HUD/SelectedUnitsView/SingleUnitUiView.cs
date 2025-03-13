using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
    public class SingleUnitUiView : BaseUnitView
    {
        [field: SerializeField] public Image PortraitView { get; private set; }

        public override void Hide()
        {
            base.Hide();

            PortraitView.sprite = null;
        }
    }
}