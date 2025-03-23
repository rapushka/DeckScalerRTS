using Entitas.Generic;

namespace DeckScaler
{
    public static class UnitUtils
    {
        public static void Select(Entity<GameScope> unit)
            => CreateEntity.OneFrame()
                .Add<SelectUnitEvent, EntityID>(unit.ID());

        public static Entity<GameScope> IntoFella(Entity<GameScope> unit)
            => unit
                .RemoveSafely<ChildOf>()
                .Add<OnSide, Side>(Side.Player)
                .Add<OnPlayerSide>()
                .Add<Fella>();

        public static Entity<GameScope> IntoEnemy(Entity<GameScope> unit, EntityID tentID)
            => unit
                .Add<OnSide, Side>(Side.Enemy)
                .Add<OnEnemySide>()
                .Add<OnTent, EntityID>(tentID)
                .Add<ChildOf, EntityID>(tentID);
    }
}