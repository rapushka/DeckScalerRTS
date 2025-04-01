using Entitas.Generic;

namespace DeckScaler
{
    public sealed class SelectedUnitUi : ValueComponent<SelectedUnitsUiView>, IInScope<UiScope> { }

    public sealed class DisplayingSingleUnitSelected : FlagComponent, IInScope<UiScope> { }

    public sealed class DisplayingMultipleUnitsSelected : FlagComponent, IInScope<UiScope> { }

    public sealed class Displaying : FlagComponent, IInScope<UiScope> { }
}