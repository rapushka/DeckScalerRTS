using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class CalculateStatsSystem : IExecuteSystem
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
                var baseStats = unit.Get<BaseStats>().Value;
                var modifiers = unit.Get<StatModifiers>().Value;

                Calculate<MovementSpeed>(StatID.MovementSpeed);

                continue;

                void Calculate<TComponent>(StatID key)
                    where TComponent : ValueComponent<float>, IInScope<GameScope>, new()
                {
                    unit.Set<TComponent, float>(baseStats[key].Modify(modifiers[key]));
                }
            }
        }
    }
}