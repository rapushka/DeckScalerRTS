using Entitas.Generic;

namespace DeckScaler
{
    // item UI -> its current slot UI
    public sealed class ItemUiInSlotUi : ValueComponent<UiEntityID>, IInScope<UiScope> { }
}