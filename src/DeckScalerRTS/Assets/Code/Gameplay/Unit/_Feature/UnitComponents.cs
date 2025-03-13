using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class UnitID : ValueComponent<UnitIDRef>, IInScope<GameScope> { }

    public sealed class HeadSprite : ValueComponent<Sprite>, IInScope<GameScope>, IEvent<Self> { }
}