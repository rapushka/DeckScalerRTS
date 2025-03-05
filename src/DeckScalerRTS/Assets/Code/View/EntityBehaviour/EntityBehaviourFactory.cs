using UnityEngine;

namespace DeckScaler
{
    public interface IEntityBehaviourFactory : IService
    {
        EntityBehaviour CreateUnitView(Vector2 position);

        EntityBehaviour CreateOrderView(Vector2 position);

        EntityBehaviour CreateTentView(Vector2 position);
    }

    public class EntityBehaviourFactory : IEntityBehaviourFactory
    {
        private static IGameConfig Configs => ServiceLocator.Resolve<IGameConfig>();

        public EntityBehaviour CreateUnitView(Vector2 position)
            => CreateBehaviour(Configs.Units.UnitViewPrefab, position);

        public EntityBehaviour CreateOrderView(Vector2 position)
            => CreateBehaviour(Configs.Units.UI.TargetView, position);

        public EntityBehaviour CreateTentView(Vector2 position)
            => CreateBehaviour(Configs.Levels.TentView, position);

        private static EntityBehaviour CreateBehaviour(EntityBehaviour prefab, Vector2 position)
        {
            var entity = CreateEntity.Empty();
            var view = Object.Instantiate(prefab, position, Quaternion.identity);
            view.Register(entity);

            entity
                .Add<View, EntityBehaviour>(view)
                ;

            return view;
        }
    }
}