using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class MarkDeadUnitsProcessed : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _units
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<Dead>()
                .Build();

        public void Execute()
        {
            foreach (var unit in _units)
                unit.Is<Processed>(true);
        }
    }
}