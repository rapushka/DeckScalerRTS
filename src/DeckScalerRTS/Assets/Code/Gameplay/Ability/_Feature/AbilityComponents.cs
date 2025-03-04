using Entitas.Generic;

namespace DeckScaler
{
    public sealed class Range : ValueComponent<float>, IInScope<GameScope> { }

    public sealed class Cooldown : ValueComponent<float>, IInScope<GameScope> { }

    public sealed class AbilityOf : IndexComponent<EntityID>, IInScope<GameScope> { }

    /// The shortest range of all offencive abilities of the Unit
    public sealed class EffectiveRange : ValueComponent<float>, IInScope<GameScope> { }

    // # Target Types
    public sealed class UseOnOpponent : FlagComponent, IInScope<GameScope> { }
}