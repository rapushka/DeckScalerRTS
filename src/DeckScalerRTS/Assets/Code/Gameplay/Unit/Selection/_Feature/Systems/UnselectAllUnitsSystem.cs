using System.Collections.Generic;
using DeckScaler.Scope;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class UnselectAllUnitsSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _events
            = GroupBuilder<GameScope>
                .With<SelectUnitEvent>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _selectedUnits
            = GroupBuilder<GameScope>
                .With<SelectedUnit>()
                .Build();

        private readonly List<Entity<GameScope>> _buffer = new(64);

        public void Execute()
        {
            foreach (var _ in _events)
            foreach (var unit in _selectedUnits.GetEntities(_buffer))
            {
                unit.Is<SelectedUnit>(false);
            }
        }
    }
}