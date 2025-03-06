using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class SelectedUnit : FlagComponent, IInScope<GameScope>, IEvent<Self> { }

    public sealed class SelectUnitEvent : ValueComponent<EntityID>, IInScope<GameScope> { }

    public sealed class SelectionOrigin : ValueComponent<Vector2>, IInScope<GameScope> { }
}