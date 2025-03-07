using System;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public static class EntityGroupExtensions
    {
        public static bool Any<TScope>(this IGroup<Entity<TScope>> @this)
            where TScope : IScope
            => @this.count > 0;

        public static Entity<TScope> First<TScope>(this IGroup<Entity<TScope>> @this)
            where TScope : IScope
        {
            foreach (var entity in @this)
                return entity;

            throw new InvalidOperationException("The group is empty");
        }
    }
}