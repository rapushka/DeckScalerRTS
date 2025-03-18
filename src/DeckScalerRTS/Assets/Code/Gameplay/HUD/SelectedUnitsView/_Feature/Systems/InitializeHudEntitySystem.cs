using Entitas;

namespace DeckScaler
{
    public class InitializeHudEntitySystem : IInitializeSystem
    {
        private static SelectedUnitsUiView SelectionUI => HUD.SelectedUnitView;

        private static GameplayHUDPage HUD => UiMediator.GetPage<GameplayHUDPage>();

        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        public void Initialize()
        {
            CreateUiEntity.Empty()
                .Add<DebugName, string>("Selected Unit HUD")
                .Add<Hud, GameplayHUDPage>(HUD)
                .Add<SelectedUnitUi, SelectedUnitsUiView>(SelectionUI)
                ;
        }
    }
}