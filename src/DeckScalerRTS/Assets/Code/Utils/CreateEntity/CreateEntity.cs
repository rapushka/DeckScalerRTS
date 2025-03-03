using DeckScaler.Scope;
using Entitas.Generic;

namespace DeckScaler
{
    public class CreateEntity
    {
        private static ScopeContext<GameScope>  GameContext  => Contexts.Instance.Get<GameScope>();
        private static ScopeContext<InputScope> InputContext => Contexts.Instance.Get<InputScope>();

        public static Entity<GameScope> Empty() => GameContext.CreateEntity();

        public static Entity<InputScope> EmptyInput() => InputContext.CreateEntity();
    }
}