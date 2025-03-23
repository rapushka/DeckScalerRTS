using UnityEngine;

namespace DeckScaler
{
    public interface IViewFactory : IService
    {
        void Init();
        void Dispose();

        EntityBehaviour CreateInUI(EntityBehaviour prefab) => CreateInUI(prefab, Vector2.zero);

        EntityBehaviour CreateInUI(EntityBehaviour prefab, Vector2 position);
        EntityBehaviour CreateInWorld(EntityBehaviour prefab, Vector2 position);
    }

    public class ViewFactory : IViewFactory
    {
        private Transform _worldRoot;
        private RectTransform _uiRoot;

        private static IUiService Ui => ServiceLocator.Resolve<IUiService>();

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

        public EntityBehaviour CreateInUI(EntityBehaviour prefab, Vector2 position)
            => CreateBehaviour(prefab, position, _uiRoot);

        public EntityBehaviour CreateInWorld(EntityBehaviour prefab, Vector2 position)
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