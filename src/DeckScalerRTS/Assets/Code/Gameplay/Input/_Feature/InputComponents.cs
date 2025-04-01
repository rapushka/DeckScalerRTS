using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class PlayerInput : FlagComponent, IInScope<InputScope> { }

    public sealed class MouseWorldPosition : ValueComponent<Vector2>, IInScope<InputScope> { }

    public sealed class MouseScreenPosition : ValueComponent<Vector2>, IInScope<InputScope> { }

    public sealed class PreviousMouseScreenPosition : ValueComponent<Vector2>, IInScope<InputScope> { }

    public sealed class OrderClicked : FlagComponent, IInScope<InputScope> { }

    public sealed class OverUI : FlagComponent, IInScope<InputScope> { }

    // Select
    public sealed class SelectClicked : FlagComponent, IInScope<InputScope> { }

    public sealed class SelectJustDown : FlagComponent, IInScope<InputScope> { }

    public sealed class SelectDown : FlagComponent, IInScope<InputScope> { }

    public sealed class SelectJustUp : FlagComponent, IInScope<InputScope> { }
}