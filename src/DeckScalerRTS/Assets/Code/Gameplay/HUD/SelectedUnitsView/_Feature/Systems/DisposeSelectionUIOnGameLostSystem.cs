using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class DisposeSelectionUIOnGameLostSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _events
            = GroupBuilder<GameScope>
                .With<GameLostEvent>()
                .Build();

        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        private static SelectedUnitsUiView SelectionUI => UiMediator.GetPage<GameplayHUDPage>().SelectedUnitView;

        public void Execute()
        {
            foreach (var _ in _events)
                SelectionUI.Hide();
        }
    }
}