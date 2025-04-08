using Entitas.Generic;

namespace DeckScaler
{
    public sealed class Influence : FlagComponent, IInScope<GameScope> { }

    public sealed class TargetStat : ValueComponent<StatID>, IInScope<GameScope> { }

    public sealed class InfluenceModifier : ValueComponent<Modifier>, IInScope<GameScope> { }

    public sealed class InfluenceOwner : IndexComponent<EntityID>, IInScope<GameScope> { }

    public sealed class InfluenceTarget : IndexComponent<EntityID>, IInScope<GameScope> { }
}