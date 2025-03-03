using DeckScaler.Scope;
using Entitas.Generic;
using JetBrains.Annotations;

namespace DeckScaler
{
    public static class EntityIDExtensions
    {
        private static PrimaryEntityIndex<GameScope, ID, EntityID> Index
            => Contexts.Instance.EntityIDIndex();

        public static PrimaryEntityIndex<GameScope, ID, EntityID> EntityIDIndex(this Contexts contexts)
            => contexts.Get<GameScope>().GetPrimaryIndex<ID, EntityID>();

        public static EntityID ID(this Entity<GameScope> @this) => @this.Get<ID>().Value;

        public static Entity<GameScope> GetEntity(this EntityID @this) => Index.GetEntity(@this);

        [CanBeNull]
        public static Entity<GameScope> GetEntityOrDefault(this EntityID @this) => Index.GetEntityOrDefault(@this);

        public static bool TryGetEntity(this EntityID @this, out Entity<GameScope> entity) => Index.TryGetEntity(@this, out entity);

        public static Entity<GameScope> GetByID<TComponent>(this Entity<GameScope> @this)
            where TComponent : ValueComponent<EntityID>, IInScope<GameScope>, new()
            => @this.Get<TComponent, EntityID>().GetEntity();

        public static Entity<GameScope> SetByID<TComponent>(this Entity<GameScope> @this, Entity<GameScope> other)
            where TComponent : ValueComponent<EntityID>, IInScope<GameScope>, new()
        {
            @this.Set<TComponent, EntityID>(other.Get<ID, EntityID>());
            return @this;
        }
    }
}