using Entitas.Generic;

namespace DeckScaler
{
    public sealed class AbilityValue : ValueComponent<float>, IInScope<GameScope> { }

    public sealed class Range : ValueComponent<float>, IInScope<GameScope> { }

    public sealed class BaseCooldown : ValueComponent<float>, IInScope<GameScope> { }

    public sealed class AbilityOf : IndexComponent<EntityID>, IInScope<GameScope> { }

    public sealed class CooldownTimer : ValueComponent<Timer>, IInScope<GameScope> { }

    public sealed class CooldownUp : FlagComponent, IInScope<GameScope> { }

    public sealed class Used : FlagComponent, IInScope<GameScope> { }

    /// The shortest range of all offencive abilities of the Unit
    public sealed class EffectiveRange : ValueComponent<float>, IInScope<GameScope> { }

    // # Target Types
    public sealed class UseOnOpponent : FlagComponent, IInScope<GameScope> { }
}