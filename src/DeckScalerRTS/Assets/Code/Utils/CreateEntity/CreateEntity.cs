using DeckScaler.Scope;
using Entitas.Generic;

namespace DeckScaler
{
    public class CreateEntity
    {
        private static ScopeContext<GameScope>  GameContext  => Contexts.Instance.Get<GameScope>();
        private static ScopeContext<InputScope> InputContext => Contexts.Instance.Get<InputScope>();

        private static IIdentifiesService Identifies => ServiceLocator.Resolve<IIdentifiesService>();

        public static Entity<GameScope> OneFrame()
            => Empty().Add<Destroy>();

        public static Entity<GameScope> Empty()
            => GameContext.CreateEntity()
                .Add<ID, EntityID>(new(Identifies.Next()));

        public static Entity<InputScope> EmptyInput() => InputContext.CreateEntity();
    }
}