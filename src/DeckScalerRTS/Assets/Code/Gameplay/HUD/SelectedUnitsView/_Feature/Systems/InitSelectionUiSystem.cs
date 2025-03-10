using Entitas;

namespace DeckScaler
{
    public sealed class InitSelectionUiSystem : IInitializeSystem
    {
        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        private static SelectedUnitsUiView SelectionUI => UiMediator.GetPage<GameplayHUDPage>().SelectedUnitView;

        public void Initialize()
        {
            SelectionUI.Hide();
        }
    }
}