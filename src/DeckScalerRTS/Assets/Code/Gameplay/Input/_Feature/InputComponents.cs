using DeckScaler.Scope;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class PlayerInput : FlagComponent, IInScope<InputScope> { }

    public sealed class AccumulatedMouseMovement : ValueComponent<Vector2>, IInScope<InputScope> { }

    public sealed class MouseWorldPosition : ValueComponent<Vector2>, IInScope<InputScope> { }

    public sealed class JustClicked : FlagComponent, IInScope<InputScope> { }
}