using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
    public class SingleUnitUiView : BaseUnitView
    {
        [SerializeField] private InventoryUI _inventory;

        [field: SerializeField] public Image PortraitView { get; private set; }

        public override void Hide()
        {
            base.Hide();

            PortraitView.sprite = null;
        }
    }
}