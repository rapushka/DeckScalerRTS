using DeckScaler.Scope;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class UnitID : ValueComponent<string>, IInScope<Game> { }

    public sealed class HeadSprite : ValueComponent<Sprite>, IInScope<Game>, IEvent<Self> { }
}