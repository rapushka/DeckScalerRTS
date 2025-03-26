using Entitas.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
    public class SingleUnitUiView : BaseUnitView
    {
        [SerializeField] private InventoryUI _inventory;

        [field: SerializeField] public Image PortraitView { get; private set; }

        public void CreateInventoryFor(Entity<GameScope> unit) => _inventory.CreateInventory(unit);

        public void UpdateInventory(Entity<GameScope> unit) => _inventory.UpdateView(unit);

        public override void Dispose()
        {
            base.Dispose();

            _inventory.Clear();
        }

        public override void Hide()
        {
            base.Hide();

            PortraitView.sprite = null;
        }
    }
}