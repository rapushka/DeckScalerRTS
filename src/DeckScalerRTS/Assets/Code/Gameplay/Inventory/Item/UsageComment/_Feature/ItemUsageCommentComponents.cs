using Entitas.Generic;

namespace DeckScaler
{
    public sealed class UseComment : ValueComponent<string>, IInScope<UiScope>, IEvent<Self> { }

    public sealed class ValidUsage : ValueComponent<bool>, IInScope<UiScope> { }
}