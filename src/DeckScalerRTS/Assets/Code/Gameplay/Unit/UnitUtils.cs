using Entitas.Generic;

namespace DeckScaler
{
    public static class UnitUtils
    {
        public static void Select(Entity<GameScope> unit)
            => CreateEntity.OneFrame()
                .Add<SelectUnitEvent, EntityID>(unit.ID());

        public static Entity<GameScope> Hire(Entity<GameScope> unit)
            => unit
                .RemoveSafely<ChildOf>()
                .Add<OnSide, Side>(Side.Player)
                .Add<OnPlayerSide>()
                .Add<Fella>();
    }
}