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
                .Add<DebugName>()
                .Add<SelectedUnitUi, SelectedUnitsUiView>(SelectionUI)
                ;
        }
    }
}