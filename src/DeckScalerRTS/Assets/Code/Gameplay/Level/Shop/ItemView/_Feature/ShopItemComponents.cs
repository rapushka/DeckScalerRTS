using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class BuyStockButton : FlagComponent, IInScope<GameScope> { }

    public sealed class ShopStockItemRoot : ValueComponent<Transform>, IInScope<GameScope> { }
}