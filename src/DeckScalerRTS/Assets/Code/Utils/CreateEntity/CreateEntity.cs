using DeckScaler.Scope;
using Entitas.Generic;

namespace DeckScaler
{
    public class CreateEntity
    {
        private static ScopeContext<Game> Context => Contexts.Instance.Get<Game>();

        public static Entity<Game> Empty() => Context.CreateEntity();
    }
}