using UnityEngine;

namespace DeckScaler
{
    public interface IEntityBehaviourFactory : IService
    {
        void Init();
        void Dispose();

        EntityBehaviour CreateUnitView(Vector2 position);

        EntityBehaviour CreateOrderView(Vector2 position);

        EntityBehaviour CreateTentView(Vector2 position);

        EntityBehaviour CreateSelectionView();

        EntityBehaviour CreateShopView(Vector2 position);

        EntityBehaviour CreateShopStockView(Vector2 position);
    }

    public class EntityBehaviourFactory : IEntityBehaviourFactory
    {
        private Transform _worldRoot;
        private RectTransform _uiRoot;

        private static IGameConfig Configs => ServiceLocator.Resolve<IGameConfig>();
        private static IUiService  Ui      => ServiceLocator.Resolve<IUiService>();

        public void Init()
        {
            _uiRoot = Ui.Canvas;
            _worldRoot = new GameObject("[Entity Behaviours]").transform;
        }

        public void Dispose()
        {
            _uiRoot = null;

            _worldRoot.DestroyObject();
            _worldRoot = null;
        }

        public EntityBehaviour CreateUnitView(Vector2 position)
            => CreateWorldView(Configs.Units.UnitViewPrefab, position);

        public EntityBehaviour CreateOrderView(Vector2 position)
            => CreateWorldView(Configs.Units.UI.TargetViewPrefab, position);

        public EntityBehaviour CreateTentView(Vector2 position)
            => CreateWorldView(Configs.Levels.TentView, position);

        public EntityBehaviour CreateSelectionView()
            => CreateUiView(Configs.Units.UI.SelectionViewPrefab, Vector2.zero);

        public EntityBehaviour CreateShopView(Vector2 position)
            => CreateWorldView(Configs.Economy.Shop.ViewPrefab, position);

        public EntityBehaviour CreateShopStockView(Vector2 position)
            => CreateWorldView(Configs.Economy.Shop.StockViewPrefab, position);

        private EntityBehaviour CreateUiView(EntityBehaviour prefab, Vector2 position)
            => CreateBehaviour(prefab, position, _uiRoot);

        private EntityBehaviour CreateWorldView(EntityBehaviour prefab, Vector2 position)
            => CreateBehaviour(prefab, position, _worldRoot);

        private static EntityBehaviour CreateBehaviour(EntityBehaviour prefab, Vector2 position, Transform parent)
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