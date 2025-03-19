using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class Shop : FlagComponent, IInScope<GameScope> { }

    public sealed class ShopSlotsRoot : ValueComponent<Transform>, IInScope<GameScope> { }

    public sealed class ItemInShop : IndexComponent<EntityID>, IInScope<GameScope> { }

    public sealed class Price : ValueComponent<int>, IInScope<GameScope> { }
}