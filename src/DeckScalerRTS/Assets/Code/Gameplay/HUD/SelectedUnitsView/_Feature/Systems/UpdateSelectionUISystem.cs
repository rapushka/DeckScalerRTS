using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class UpdateSelectionUISystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _selectedUnits
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<SelectedUnit>()
                .Build();

        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        public void Execute()
        {
            if (!_selectedUnits.Any())
                return;

            var hud = UiMediator.GetPage<GameplayHUDPage>();
            hud.SelectedUnitView.UpdateValue();
        }
    }
}