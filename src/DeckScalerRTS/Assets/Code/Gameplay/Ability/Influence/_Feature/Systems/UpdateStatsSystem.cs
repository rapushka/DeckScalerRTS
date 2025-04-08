using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class UpdateStatsSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _influences
            = GroupBuilder<GameScope>
                .With<Influence>()
                .And<InfluenceTarget>()
                .And<TargetStat>()
                .And<InfluenceModifier>()
                .Build();

        public void Execute()
        {
            foreach (var influence in _influences)
            {
                var stat = influence.Get<TargetStat>().Value;
                var target = influence.Get<InfluenceTarget>().Value.GetEntity();
                var modifiers = target.Get<StatModifiers>().Value;
                var influenceValue = influence.Get<InfluenceModifier>().Value;

                target.Set<StatModifiers, StatMods>(modifiers.Add(stat, influenceValue));
            }
        }
    }
}