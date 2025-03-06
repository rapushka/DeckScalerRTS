using Entitas;

namespace DeckScaler
{
    public sealed class InitializeSelectionRectViewSystem : IInitializeSystem
    {
        private static IUiFactory UiFactory => ServiceLocator.Resolve<IUiFactory>();

        public void Initialize()
        {
            UiFactory.CreateSelectionView();
        }
    }
}