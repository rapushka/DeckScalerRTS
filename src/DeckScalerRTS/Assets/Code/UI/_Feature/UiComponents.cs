using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class HoveredByMouse : FlagComponent, IInScope<UiScope> { }

    public sealed class ScreenPosition : ValueComponent<Vector2>, IInScope<UiScope>, IEvent<Self> { }

    public sealed class RaycastTarget : ValueComponent<bool>, IInScope<UiScope>, IEvent<Self> { }
}