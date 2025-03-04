using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class OrderOnPositionEvent : ValueComponent<Vector2>, IInScope<GameScope> { }

    public sealed class OrderListener : ValueComponent<EntityID>, IInScope<GameScope> { }

    /// Exists only for view
    public sealed class ProcessedAsAttackOrder : FlagComponent, IInScope<GameScope> { }
}