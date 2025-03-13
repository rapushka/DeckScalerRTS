using Entitas.Generic;

namespace DeckScaler
{
    public static class CreateEntity
    {
        private static ScopeContext<GameScope> Context => Contexts.Instance.Get<GameScope>();

        private static IIdentifiesService Identifies => ServiceLocator.Resolve<IIdentifiesService>();

        public static Entity<GameScope> OneFrame()
            => Empty().Add<Destroy>();

        public static Entity<GameScope> Empty()
            => Context.CreateEntity()
                .Add<ID, EntityID>(new(Identifies.Next()));
    }

    public static class CreateInputEntity
    {
        private static ScopeContext<InputScope> Context => Contexts.Instance.Get<InputScope>();

        public static Entity<InputScope> Empty() => Context.CreateEntity();
    }

    public static class CreateUiEntity
    {
        private static ScopeContext<UiScope> Context => Contexts.Instance.Get<UiScope>();

        public static Entity<UiScope> Empty() => Context.CreateEntity();
    }
}