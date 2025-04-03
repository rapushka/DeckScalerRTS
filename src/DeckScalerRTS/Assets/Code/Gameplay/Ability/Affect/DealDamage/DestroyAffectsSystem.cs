using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class DestroyAffectsSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _affects
            = GroupBuilder<GameScope>
                .With<Affect>()
                .Build();

        public void Execute()
        {
            foreach (var affect in _affects)
                affect.Is<Destroy>(true);
        }
    }
}