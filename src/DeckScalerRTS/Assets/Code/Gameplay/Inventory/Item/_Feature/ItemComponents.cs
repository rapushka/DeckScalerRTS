using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class ItemID : ValueComponent<ItemIDRef>, IInScope<GameScope> { }

    public sealed class LyingOnGround : FlagComponent, IInScope<GameScope> { }

    public sealed class ItemSprite : ValueComponent<Sprite>, IInScope<GameScope>, IInScope<UiScope>, IEvent<Self> { }
}