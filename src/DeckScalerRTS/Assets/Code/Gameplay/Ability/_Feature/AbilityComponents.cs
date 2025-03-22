using Entitas.Generic;

namespace DeckScaler
{
    public sealed class AbilityAffectConfig : ValueComponent<AffectConfig>, IInScope<GameScope> { }

    public sealed class Range : ValueComponent<float>, IInScope<GameScope> { }

    public sealed class BaseCooldown : ValueComponent<float>, IInScope<GameScope> { }

    // Ability -> Unit (this Ability belongs to)
    public sealed class AbilityOwner : IndexComponent<EntityID>, IInScope<GameScope> { }

    public sealed class CooldownTimer : ValueComponent<Timer>, IInScope<GameScope> { }

    public sealed class CooldownUp : FlagComponent, IInScope<GameScope> { }

    public sealed class Used : FlagComponent, IInScope<GameScope> { }

    /// The shortest range of all offencive abilities of the Unit
    public sealed class EffectiveRange : ValueComponent<float>, IInScope<GameScope> { }

    // # Trigger Types
    public sealed class CastOnOpponent : FlagComponent, IInScope<GameScope> { }

    public sealed class CastWhenOwnerKilledUnit : FlagComponent, IInScope<GameScope> { }
}