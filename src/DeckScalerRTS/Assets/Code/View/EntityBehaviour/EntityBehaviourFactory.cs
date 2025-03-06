using UnityEngine;

namespace DeckScaler
{
    public interface IEntityBehaviourFactory : IService
    {
        EntityBehaviour CreateUnitView(Vector2 position);

        EntityBehaviour CreateOrderView(Vector2 position);

        EntityBehaviour CreateTentView(Vector2 position);

        EntityBehaviour CreateSelectionView();
    }

    public class EntityBehaviourFactory : IEntityBehaviourFactory
    {
        private static IGameConfig Configs => ServiceLocator.Resolve<IGameConfig>();
        private static IUiService  Ui      => ServiceLocator.Resolve<IUiService>();

        public EntityBehaviour CreateUnitView(Vector2 position)
            => CreateBehaviour(Configs.Units.UnitViewPrefab, position);

        public EntityBehaviour CreateOrderView(Vector2 position)
            => CreateBehaviour(Configs.Units.UI.TargetViewPrefab, position);

        public EntityBehaviour CreateTentView(Vector2 position)
            => CreateBehaviour(Configs.Levels.TentView, position);

        public EntityBehaviour CreateSelectionView()
            => CreateBehaviour(Configs.Units.UI.SelectionViewPrefab, Vector2.zero, Ui.Canvas);

        private static EntityBehaviour CreateBehaviour(EntityBehaviour prefab, Vector2 position, Transform parent = null)
        {
            var entity = CreateEntity.Empty();
            var view = Object.Instantiate(prefab, parent);
            view.transform.position = position;
            view.Register(entity);

            entity
                .Add<View, EntityBehaviour>(view)
                ;

            return view;
        }
    }
}