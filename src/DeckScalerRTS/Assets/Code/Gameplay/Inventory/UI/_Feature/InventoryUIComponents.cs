using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    /// Slots & Items
    public sealed class InventoryPart : FlagComponent, IInScope<UiScope> { }

    // Slot UI -> Slot Model
    public sealed class UiOfInventorySlot : IndexComponent<EntityID>, IInScope<UiScope> { }

    // Item UI -> Item Model
    public sealed class UiOfItem : IndexComponent<EntityID>, IInScope<UiScope> { }

    public sealed class UiParent : ValueComponent<RectTransform>, IInScope<UiScope>, IEvent<Self> { }

    public sealed class InitUiParent : ValueComponent<RectTransform>, IInScope<UiScope> { }

    public sealed class Highlight : FlagComponent, IInScope<UiScope>, IEvent<Self> { }
}