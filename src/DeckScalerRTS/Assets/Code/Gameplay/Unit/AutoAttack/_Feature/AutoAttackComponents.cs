using Entitas.Generic;

namespace DeckScaler
{
    public sealed class InAutoAttackState : FlagComponent, IInScope<GameScope> { }

    public sealed class AgroTriggerRadius : ValueComponent<float>, IInScope<GameScope> { }

    public sealed class FlipSelectedUnitAttackStateEvent : FlagComponent, IInScope<GameScope> { }
}