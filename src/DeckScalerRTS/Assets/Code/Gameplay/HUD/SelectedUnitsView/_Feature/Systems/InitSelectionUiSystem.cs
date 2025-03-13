using Entitas;

namespace DeckScaler
{
    public class InitSelectionUiSystem : IInitializeSystem
    {
        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        private static SelectedUnitsUiView SelectionUI => UiMediator.GetPage<GameplayHUDPage>().SelectedUnitView;

        public void Initialize()
        {
            CreateUiEntity.Empty()
                .Add<DebugName, string>("Selected Unit HUD")
                .Add<SelectedUnitUi, SelectedUnitsUiView>(SelectionUI)
                ;
        }
    }
}