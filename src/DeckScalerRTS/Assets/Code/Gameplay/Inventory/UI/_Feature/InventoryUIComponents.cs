using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    // Slot UI -> Slot Model
    public sealed class InventoryItemSlotUiView : ValueComponent<EntityID>, IInScope<UiScope> { }

    public sealed class UiParent : ValueComponent<RectTransform>, IInScope<UiScope>, IEvent<Self> { }

    public sealed class InitUiParent : ValueComponent<RectTransform>, IInScope<UiScope> { }
}