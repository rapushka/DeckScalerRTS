using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class Shop : FlagComponent, IInScope<GameScope> { }

    public sealed class ShopSlotsRoot : ValueComponent<Transform>, IInScope<GameScope> { }

    /// Slot -> Shop
    public sealed class StockInShop : IndexComponent<EntityID>, IInScope<GameScope> { }

    /// Slot -> Item (Unit or Trinket)
    public sealed class IssuedItem : IndexComponent<EntityID>, IInScope<GameScope> { }

    public sealed class Price : ValueComponent<int>, IInScope<GameScope>, IEvent<Self> { }

    public sealed class ItemForSale : ValueComponent<int>, IInScope<GameScope>, IEvent<Self> { }

    public sealed class JustPurchased : FlagComponent, IInScope<GameScope> { }
}