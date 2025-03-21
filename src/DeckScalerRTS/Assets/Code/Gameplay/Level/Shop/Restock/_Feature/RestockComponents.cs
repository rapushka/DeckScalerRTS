using Entitas.Generic;

namespace DeckScaler
{
    public sealed class Restock : FlagComponent, IInScope<GameScope> { }

    /// Button -> Shop
    public sealed class RestockButton : ValueComponent<EntityID>, IInScope<GameScope> { }
}