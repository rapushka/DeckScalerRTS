using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class DestroyInventoryUIOnUnitSelectedSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _events
            = GroupBuilder<GameScope>
                .With<SelectUnitEvent>()
                .Build();

        private readonly IGroup<Entity<UiScope>> _inventoryParts
            = GroupBuilder<UiScope>
                .With<InventoryPart>()
                .Build();

        public void Execute()
        {
            foreach (var _ in _events)
            foreach (var inventoryPart in _inventoryParts)
                inventoryPart.Is<Destroy>(true);
        }
    }
}