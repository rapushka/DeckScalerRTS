using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class SelectedUnit : FlagComponent, IInScope<GameScope>, IEvent<Self> { }

    public sealed class SelectUnitEvent : ValueComponent<EntityID>, IInScope<GameScope> { }

    /// TODO: in theory this isn't needed anymore
    public sealed class SelectionWorldOrigin : ValueComponent<Vector2>, IInScope<GameScope> { }
}