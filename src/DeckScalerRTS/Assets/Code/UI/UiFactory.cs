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
                    .Add<WorldPosition, Vector2>(Vector2.zero)
                    .Add<SelectionWorldOrigin, Vector2>(Vector2.zero)
                ;

            var rect = selection.Get<SelectionRect>().Value;
            rect.Hide();

            return selection;
        }
    }
}