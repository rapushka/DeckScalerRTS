using System;
using System.Collections.Generic;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public static class EntityGroupExtensions
    {
        public static bool Any<TScope>(this IGroup<Entity<TScope>> @this, Func<Entity<TScope>, bool> predicate)
            where TScope : IScope
        {
            foreach (var entity in @this)
            {
                if (predicate.Invoke(entity))
                    return true;
            }

            return false;
        }

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

        public static string JoinToString<TEntity>(this IGroup<TEntity> @this, string separator = ", ")
            where TEntity : class, IEntity
            => string.Join(separator, @this);

        public static IEnumerable<TResult> Select<TEntity, TResult>(this IGroup<TEntity> @this, Func<TEntity, TResult> selector)
            where TEntity : class, IEntity
        {
            foreach (var entity in @this)
                yield return selector.Invoke(entity);
        }
    }
}