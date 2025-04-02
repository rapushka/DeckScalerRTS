using Entitas.Generic;

namespace DeckScaler
{
    public sealed class ID : PrimaryIndexComponent<EntityID>, IInScope<GameScope> { }

    public sealed class UiID : PrimaryIndexComponent<UiEntityID>, IInScope<UiScope> { }
}