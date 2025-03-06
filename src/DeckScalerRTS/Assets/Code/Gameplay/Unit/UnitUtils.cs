using Entitas.Generic;

namespace DeckScaler
{
    public static class UnitUtils
    {
        public static void Select(Entity<GameScope> unit)
            => CreateEntity.OneFrame()
                .Add<SelectUnitEvent, EntityID>(unit.ID());
    }
}