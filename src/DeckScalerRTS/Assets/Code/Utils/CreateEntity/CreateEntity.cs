using Entitas.Generic;

namespace DeckScaler
{
    public static class CreateEntity
    {
        private static ScopeContext<GameScope> Context => Contexts.Instance.Get<GameScope>();

        private static IIdentifiesService Identifies => ServiceLocator.Resolve<IIdentifiesService>();

        public static Entity<TScope> ScopeBased<TScope>()
            where TScope : IScope
        {
            var entity = Contexts.Instance.Get<TScope>().CreateEntity();

            if (entity is Entity<GameScope> gameEntity)
                Identify(gameEntity);

            return entity;
        }

        public static Entity<GameScope> OneFrame()
            => Empty().Add<Destroy>();

        public static Entity<GameScope> Empty() => Identify(Context.CreateEntity());

        private static Entity<GameScope> Identify(Entity<GameScope> entity) => entity
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