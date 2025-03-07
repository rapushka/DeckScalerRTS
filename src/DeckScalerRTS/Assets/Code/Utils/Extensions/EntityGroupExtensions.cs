using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public static class EntityGroupExtensions
    {
        public static bool Any<TScope>(this IGroup<Entity<TScope>> @this) where TScope : IScope
        {
            foreach (var _ in @this)
                return true;

            return false;
        }
    }
}