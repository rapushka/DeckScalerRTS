using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public interface IUiFactory : IService
    {
        Entity<GameScope> CreateSelectionView();
    }

    public class UiFactory : IUiFactory
    {
        private static IViewFactory ViewFactory => ServiceLocator.Resolve<IViewFactory>();

        private static UnitsConfig.UiConfig UnitsUIConfig => ServiceLocator.Resolve<IGameConfig>().Units.UI;

        public Entity<GameScope> CreateSelectionView()
        {
            var selection = ViewFactory.CreateInUI(UnitsUIConfig.SelectionViewPrefab).Entity
                    .Add<DebugName, string>("selection view")
                    .Add<SelectionRect, Rect>(new())
                ;

            var rect = selection.Get<SelectionView>().Value;
            rect.Hide();

            return selection;
        }
    }
}