using DeckScaler.Scope;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class SelectedUnit : FlagComponent, IInScope<GameScope> { }

    public sealed class SelectUnitEvent : ValueComponent<EntityID>, IInScope<GameScope> { }
}