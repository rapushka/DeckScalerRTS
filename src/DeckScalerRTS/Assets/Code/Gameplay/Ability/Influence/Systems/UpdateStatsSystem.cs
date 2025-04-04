using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class UpdateStatsSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _units
            = GroupBuilder<GameScope>
                .With<BaseStats>()
                .And<StatModifiers>()
                .Build();

        private static EntityIndex<GameScope, InfluenceTarget, EntityID> Index
            => Contexts.Instance.Get<GameScope>().GetIndex<InfluenceTarget, EntityID>();

        public void Execute()
        {
            foreach (var unit in _units)
            {
                var modifiers = unit.Get<StatModifiers>().Value;
                modifiers.Reset();

                foreach (var influence in Index.GetEntities(unit.ID()))
                {
                    var stat = influence.Get<TargetStat>().Value;
                    var modifier = modifiers[stat];

                    var influenceValue = influence.Get<InfluenceValue>().Value;
                    modifier.Combine(influenceValue);
                }

                unit.Set<StatModifiers, StatMods>(modifiers);
            }
        }
    }
}