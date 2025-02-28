using UnityEngine;

namespace DeckScaler
{
    public interface IEntityBehaviourFactory : IService
    {
        EntityBehaviour CreateUnitView();
    }

    public class EntityBehaviourFactory : IEntityBehaviourFactory
    {
        private static IGameConfig Configs => ServiceLocator.Resolve<IGameConfig>();

        public EntityBehaviour CreateUnitView()
        {
            var entity = CreateEntity.Empty();
            var view = Object.Instantiate(Configs.Units.UnitViewPrefab);
            view.Register(entity);

            return view;
        }
    }
}