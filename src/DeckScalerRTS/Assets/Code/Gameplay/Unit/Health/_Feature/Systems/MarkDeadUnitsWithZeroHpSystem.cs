using System.Collections.Generic;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class MarkDeadUnitsWithZeroHpSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _units
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<Health>()
                .Without<Dead>()
                .Build();

        private readonly List<Entity<GameScope>> _buffer = new(16);

        public void Execute()
        {
            foreach (var unit in _units.GetEntities(_buffer))
            {
                var health = unit.Get<Health, float>();

                if (health <= 0)
                    unit.Is<Dead>(true);
            }
        }
    }
}