using DeckScaler.Scope;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class SelectedUnit : FlagComponent, IInScope<GameScope>, IEvent<Self> { }

    public sealed class SelectUnitEvent : ValueComponent<EntityID>, IInScope<GameScope> { }
}