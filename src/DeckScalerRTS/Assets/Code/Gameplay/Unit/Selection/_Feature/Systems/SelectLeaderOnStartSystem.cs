using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class SelectLeaderOnStartSystem : IInitializeSystem
    {
        private readonly IGroup<Entity<GameScope>> _leads
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<Lead>()
                .Build();

        public void Initialize()
        {
            foreach (var lead in _leads)
                UnitUtils.Select(lead);
        }
    }
}