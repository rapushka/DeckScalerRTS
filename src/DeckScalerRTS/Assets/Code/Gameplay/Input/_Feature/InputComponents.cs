using DeckScaler.Scope;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class PlayerInput : FlagComponent, IInScope<InputScope> { }

    public sealed class MouseDelta : ValueComponent<Vector2>, IInScope<InputScope> { }

    public sealed class MouseScreenPosition : ValueComponent<Vector2>, IInScope<InputScope> { }

    public sealed class MouseWorldPosition : ValueComponent<Vector2>, IInScope<InputScope> { }

    public sealed class JustClickedSelect : FlagComponent, IInScope<InputScope> { }

    public sealed class DraggingCamera : FlagComponent, IInScope<InputScope> { }

    public sealed class DragCameraOrigin : ValueComponent<Vector2>, IInScope<InputScope> { }
}