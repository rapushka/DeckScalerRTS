using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class UpdateSelectedUnitsUISystem : IExecuteSystem
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

        public void Execute()
        {
            foreach (var _ in _events)
            {
                var hud = UiMediator.GetPage<GameplayHUDPage>();
                hud.SelectedUnitView.UpdateUnits(_selectedUnits);
            }
        }
    }
}