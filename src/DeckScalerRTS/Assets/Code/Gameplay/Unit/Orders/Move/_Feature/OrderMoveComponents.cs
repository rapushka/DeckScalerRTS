using DeckScaler.Scope;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class OrderMoveToPosition : ValueComponent<Vector2>, IInScope<GameScope> { }
}