using DeckScaler.Scope;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class ID : PrimaryIndexComponent<EntityID>, IInScope<GameScope> { }
}