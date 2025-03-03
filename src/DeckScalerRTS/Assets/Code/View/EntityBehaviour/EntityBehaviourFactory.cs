using UnityEngine;

namespace DeckScaler
{
    public interface IEntityBehaviourFactory : IService
    {
        EntityBehaviour CreateUnitView(Vector2 position);
    }

    public class EntityBehaviourFactory : IEntityBehaviourFactory
    {
        private static IGameConfig Configs => ServiceLocator.Resolve<IGameConfig>();

        public EntityBehaviour CreateUnitView(Vector2 position)
        {
            var entity = CreateEntity.Empty();
            var view = Object.Instantiate(Configs.Units.UnitViewPrefab, position, Quaternion.identity);
            view.Register(entity);

            return view;
        }
    }
}