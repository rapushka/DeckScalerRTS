using Entitas.Generic;

namespace DeckScaler
{
    public sealed class Opponent : ValueComponent<EntityID>, IInScope<GameScope> { }

    public sealed class AttackRange : ValueComponent<float>, IInScope<GameScope> { }

    public sealed class AttackCooldown : ValueComponent<float>, IInScope<GameScope> { }
}