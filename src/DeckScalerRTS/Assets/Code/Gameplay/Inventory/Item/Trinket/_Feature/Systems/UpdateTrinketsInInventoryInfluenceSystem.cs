using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class UpdateTrinketsInInventoryInfluenceSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _trinkets
            = GroupBuilder<GameScope>
                .With<Trinket>()
                .Without<LyingOnGround>()
                .Build();

        private static EntityIndex<GameScope, InfluenceOwner, EntityID> Index
            => Contexts.Instance.Get<GameScope>().GetIndex<InfluenceOwner, EntityID>();

        public void Execute()
        {
            foreach (var trinket in _trinkets)
            {
                var unitID = trinket.GetOwnerUnitOfItem();

                foreach (var influences in Index.GetEntities(trinket.ID()))
                    influences.Set<InfluenceTarget, EntityID>(unitID);
            }
        }
    }
}