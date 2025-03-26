using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public interface IViewFactory : IService
    {
        void Init();
        void Dispose();

        EntityBehaviour<TScope> CreateInUI<TScope>(EntityBehaviour<TScope> prefab, Transform parent) where TScope : IScope;
        EntityBehaviour<TScope> CreateInUI<TScope>(EntityBehaviour<TScope> prefab, Vector2 position) where TScope : IScope;

        EntityBehaviour CreateInWorld(EntityBehaviour prefab, Vector2 position);

        EntityBehaviour<TScope> CreateInUI<TScope>(EntityBehaviour<TScope> prefab) where TScope : IScope
            => CreateInUI(prefab, Vector2.zero);
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

        public EntityBehaviour<TScope> CreateInUI<TScope>(EntityBehaviour<TScope> prefab, Vector2 position)
            where TScope : IScope
            => CreateBehaviour(prefab, position, _uiRoot);

        public EntityBehaviour<TScope> CreateInUI<TScope>(EntityBehaviour<TScope> prefab, Transform parent)
            where TScope : IScope
            => CreateBehaviour(prefab, Vector2.zero, parent);

        public EntityBehaviour CreateInWorld(EntityBehaviour prefab, Vector2 position)
            => (EntityBehaviour)CreateBehaviour(prefab, position, _worldRoot);

        private static EntityBehaviour<TScope> CreateBehaviour<TScope>(EntityBehaviour<TScope> prefab, Vector2 position, Transform parent)
            where TScope : IScope
        {
            var entity = CreateEntity.ScopeBased<TScope>();
            var view = Object.Instantiate(prefab, parent);
            view.transform.position = position;
            view.Register(entity);

            BindView(entity, view);

            return view;
        }

        private static void BindView<TScope>(Entity<TScope> entity, EntityBehaviour<TScope> view) where TScope : IScope
        {
            if (entity is Entity<GameScope> gameEntity)
                gameEntity.Add<View, EntityBehaviour>(view as EntityBehaviour);

            else if (entity is Entity<UiScope> uiEntity)
                uiEntity.Add<UiView, UiEntityBehaviour>(view as UiEntityBehaviour);
        }
    }
}