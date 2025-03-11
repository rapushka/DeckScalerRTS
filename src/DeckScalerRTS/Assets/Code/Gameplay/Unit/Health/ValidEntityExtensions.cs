using Entitas.Generic;
using JetBrains.Annotations;

namespace DeckScaler
{
    public static class ValidEntityExtensions
    {
        public static bool IsAlive([CanBeNull] this ValueComponent<EntityID> @this)
            => @this is not null && @this.Value.IsAlive();

        public static bool IsAlive(this EntityID @this)
            => @this.TryGetEntity(out var entity) && entity.IsAlive();

        public static bool IsAlive(this Entity<GameScope> @this)
            => @this.isEnabled
                && !@this.Is<Dead>()
                && !@this.Is<Destroy>();
    }
}