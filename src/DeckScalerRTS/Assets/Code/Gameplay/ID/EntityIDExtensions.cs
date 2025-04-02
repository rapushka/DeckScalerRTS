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

        public static bool HasEntity(this EntityID @this) => Index.HasEntity(@this);

        public static Entity<GameScope> GetByID<TComponent>(this Entity<GameScope> @this)
            where TComponent : ValueComponent<EntityID>, IInScope<GameScope>, new()
            => @this.Get<TComponent, EntityID>().GetEntity();

        public static Entity<GameScope> SetByID<TComponent>(this Entity<GameScope> @this, Entity<GameScope> other)
            where TComponent : ValueComponent<EntityID>, IInScope<GameScope>, new()
        {
            @this.Set<TComponent, EntityID>(other.Get<ID, EntityID>());
            return @this;
        }

#region UI
        private static PrimaryEntityIndex<UiScope, UiID, UiEntityID> UiIndex
            => Contexts.Instance.UiEntityIDIndex();

        public static PrimaryEntityIndex<UiScope, UiID, UiEntityID> UiEntityIDIndex(this Contexts contexts)
            => contexts.Get<UiScope>().GetPrimaryIndex<UiID, UiEntityID>();

        public static UiEntityID ID(this Entity<UiScope> @this) => @this.Get<UiID>().Value;

        public static Entity<UiScope> GetEntity(this UiEntityID @this) => UiIndex.GetEntity(@this);

        [CanBeNull]
        public static Entity<UiScope> GetEntityOrDefault(this UiEntityID @this) => UiIndex.GetEntityOrDefault(@this);

        public static bool TryGetEntity(this UiEntityID @this, out Entity<UiScope> entity) => UiIndex.TryGetEntity(@this, out entity);

        public static bool HasEntity(this UiEntityID @this) => UiIndex.HasEntity(@this);

        public static Entity<UiScope> GetByID<TComponent>(this Entity<UiScope> @this)
            where TComponent : ValueComponent<UiEntityID>, IInScope<UiScope>, new()
            => @this.Get<TComponent, UiEntityID>().GetEntity();

        public static Entity<UiScope> SetByID<TComponent>(this Entity<UiScope> @this, Entity<UiScope> other)
            where TComponent : ValueComponent<UiEntityID>, IInScope<UiScope>, new()
        {
            @this.Set<TComponent, UiEntityID>(other.Get<UiID, UiEntityID>());
            return @this;
        }
#endregion
    }
}