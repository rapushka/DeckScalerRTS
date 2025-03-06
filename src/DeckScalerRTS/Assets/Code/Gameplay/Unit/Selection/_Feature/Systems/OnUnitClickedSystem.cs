using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class OnUnitClickedSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _clickedUnits
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<Clicked>()
                .Build();

        public void Execute()
        {
            foreach (var unit in _clickedUnits)
                UnitUtils.Select(unit);
        }
    }
}