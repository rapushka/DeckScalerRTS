using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public static class ComponentExtensions
    {
        public static TValue Pop<TComponent, TValue>(this Entity<GameScope> @this)
            where TComponent : ValueComponent<TValue>, IInScope<GameScope>, new()
            => @this.Pop<TComponent>().Value;

        /// Get and Remove the Component from the Entity
        public static TComponent Pop<TComponent>(this Entity<GameScope> @this)
            where TComponent : IComponent, IInScope<GameScope>, new()
        {
            var component = @this.Get<TComponent>();
            @this.Remove<TComponent>();

            return component;
        }
    }
}