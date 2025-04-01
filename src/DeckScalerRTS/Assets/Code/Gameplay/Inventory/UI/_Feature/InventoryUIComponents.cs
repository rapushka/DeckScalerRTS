using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    /// Slots & Items
    public sealed class InventoryPart : FlagComponent, IInScope<UiScope> { }

    // Slot UI -> Slot Model
    public sealed class UiOfInventorySlot : PrimaryIndexComponent<EntityID>, IInScope<UiScope> { }

    public sealed class ItemUI : FlagComponent, IInScope<UiScope> { }

    public sealed class UiParent : ValueComponent<RectTransform>, IInScope<UiScope>, IEvent<Self> { }

    public sealed class InitUiParent : ValueComponent<RectTransform>, IInScope<UiScope> { }
}