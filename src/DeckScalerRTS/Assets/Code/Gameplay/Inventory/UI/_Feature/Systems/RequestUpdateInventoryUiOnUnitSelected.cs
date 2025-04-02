using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class RequestUpdateInventoryUiOnUnitSelected : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _events
            = GroupBuilder<GameScope>
                .With<SelectUnitEvent>()
                .Build();

        public void Execute()
        {
            foreach (var e in _events)
            {
                var unitToSelect = e.Get<SelectUnitEvent>().Value.GetEntity();
                unitToSelect.AddSafely<RequestUpdateInventoryUI>();
            }
        }
    }
}