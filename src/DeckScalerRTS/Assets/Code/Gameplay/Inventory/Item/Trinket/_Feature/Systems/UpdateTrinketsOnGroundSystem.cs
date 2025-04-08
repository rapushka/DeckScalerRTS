using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class UpdateTrinketsOnGroundSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _trinkets
            = GroupBuilder<GameScope>
                .With<Trinket>()
                .And<LyingOnGround>()
                .Build();

        private static EntityIndex<GameScope, InfluenceTarget, EntityID> Index
            => Contexts.Instance.Get<GameScope>().GetIndex<InfluenceTarget, EntityID>();

        public void Execute()
        {
            foreach (var trinket in _trinkets)
            foreach (var influences in Index.GetEntities(trinket.ID()))
                influences.RemoveSafely<InfluenceTarget>();
        }
    }
}