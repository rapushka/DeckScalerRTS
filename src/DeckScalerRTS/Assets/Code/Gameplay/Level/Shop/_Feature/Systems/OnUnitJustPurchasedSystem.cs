using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class OnUnitJustPurchasedSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _justPurchasedUnits
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<JustPurchased>()
                .Build();

        public void Execute()
        {
            foreach (var unit in _justPurchasedUnits)
                UnitUtils.IntoFella(unit);
        }
    }
}