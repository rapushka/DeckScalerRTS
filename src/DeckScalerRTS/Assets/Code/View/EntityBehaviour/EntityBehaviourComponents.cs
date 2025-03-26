using Entitas.Generic;

namespace DeckScaler
{
    public sealed class View : ValueComponent<EntityBehaviour>, IInScope<GameScope> { }

    public sealed class UiView : ValueComponent<UiEntityBehaviour>, IInScope<UiScope> { }
}