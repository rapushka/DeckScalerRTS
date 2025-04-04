using Entitas.Generic;

namespace DeckScaler
{
    public sealed class BaseStats : ValueComponent<Stats>, IInScope<GameScope> { }

    public sealed class StatModifiers : ValueComponent<StatMods>, IInScope<GameScope> { }
}