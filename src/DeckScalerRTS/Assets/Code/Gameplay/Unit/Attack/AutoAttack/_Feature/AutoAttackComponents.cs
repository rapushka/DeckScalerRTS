using Entitas.Generic;

namespace DeckScaler
{
    public sealed class InAutoAttackState : FlagComponent, IInScope<GameScope> { }

    public sealed class AttackTriggerRadius : ValueComponent<float>, IInScope<GameScope> { }
}