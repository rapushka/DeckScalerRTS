using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class ResetStatsSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _units
            = GroupBuilder<GameScope>
                .With<BaseStats>()
                .And<StatModifiers>()
                .Build();

        public void Execute()
        {
            foreach (var unit in _units)
            {
                var modifiers = unit.Get<StatModifiers>().Value;
                modifiers.Reset();
                unit.Set<StatModifiers, StatMods>(modifiers);
            }
        }
    }
}