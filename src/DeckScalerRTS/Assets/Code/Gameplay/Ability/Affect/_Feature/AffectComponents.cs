using Entitas.Generic;

namespace DeckScaler
{
    public sealed class Affect : FlagComponent, IInScope<GameScope> { }

    public sealed class AffectValue : ValueComponent<float>, IInScope<GameScope> { }

    public sealed class AffectSender : ValueComponent<EntityID>, IInScope<GameScope> { }

    public sealed class AffectTarget : ValueComponent<EntityID>, IInScope<GameScope> { }

    // # Types

    public sealed class DealDamageAffect : FlagComponent, IInScope<GameScope> { }
}