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
        private static IEntityBehaviourFactory EntityBehaviourFactory => ServiceLocator.Resolve<IEntityBehaviourFactory>();

        public Entity<GameScope> CreateSelectionView()
        {
            var selection = EntityBehaviourFactory.CreateSelectionView().Entity
                    .Add<DebugName, string>("selection view")
                    .Add<SelectionRect, Rect>(new())
                ;

            var rect = selection.Get<SelectionView>().Value;
            rect.Hide();

            return selection;
        }
    }
}