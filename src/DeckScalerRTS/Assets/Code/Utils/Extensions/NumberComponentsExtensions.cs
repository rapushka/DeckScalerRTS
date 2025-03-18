using Entitas.Generic;

namespace DeckScaler
{
    public static class NumberComponentsExtensions
    {
        public static Entity<GameScope> Increment<TComponent>(this Entity<GameScope> @this, int increment)
            where TComponent : ValueComponent<int>, IInScope<GameScope>, new()
            => @this.Increment<GameScope, TComponent>(increment);

        private static Entity<TScope> Increment<TScope, TComponent>(this Entity<TScope> @this, int increment)
            where TScope : IScope
            where TComponent : ValueComponent<int>, IInScope<TScope>, new()
        {
            var oldValue = @this.GetOrDefault<TComponent, int>();
            return @this.Set<TComponent, int>(oldValue + increment);
        }
    }
}