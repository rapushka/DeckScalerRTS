using Entitas.Generic;

namespace DeckScaler
{
    public sealed class Drink : FlagComponent, IInScope<GameScope> { }

    /// Unit with Drink -> Target Unit
    public sealed class UseDrinkOn : ValueComponent<EntityID>, IInScope<GameScope> { }
}