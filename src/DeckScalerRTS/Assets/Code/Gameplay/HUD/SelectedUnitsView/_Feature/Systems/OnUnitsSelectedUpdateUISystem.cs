using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class OnUnitsSelectedUpdateUISystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _events
            = GroupBuilder<GameScope>
                .With<SelectUnitEvent>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _selectedUnits
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<SelectedUnit>()
                .Build();

        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        private static SelectedUnitsUiView SelectionUI => UiMediator.GetPage<GameplayHUDPage>().SelectedUnitView;

        public void Execute()
        {
            foreach (var _ in _events)
            {
                SelectionUI.OnSelectionChanged(_selectedUnits);
            }
        }
    }
}