using UnityEngine;
using Object = UnityEngine.Object;

namespace DeckScaler
{
    public interface IPagesService : IService
    {
        void Initialize();

        void OpenPage<TPage>() where TPage : BasePage;
    }

    public class PagesService : IPagesService
    {
        private readonly TypeDictionary<BasePage> _pagePrefabsMap = new();
        private readonly TypeDictionary<BasePage> _loadedPagesMap = new();

        private BasePage _currentPage;

        private static UiConfig Config => ServiceLocator.Resolve<IGameConfig>().UI;

        private static RectTransform UiCanvas => ServiceLocator.Resolve<IUiService>().Canvas;

        public void Initialize()
        {
            foreach (var pagePrefab in Config.PagePrefabs)
                _pagePrefabsMap.Add(pagePrefab);
        }

        public void OpenPage<TPage>()
            where TPage : BasePage
        {
            _currentPage?.Hide();
            _currentPage = _loadedPagesMap.GetOrAdd(CreateNewPage<TPage>);

            _currentPage.Show();
        }

        private TPage CreateNewPage<TPage>()
            where TPage : BasePage
        {
            var pagePrefab = _pagePrefabsMap.Get<TPage>();
            var newPage = Object.Instantiate(pagePrefab, UiCanvas);

            newPage.Initialize();

            return newPage;
        }
    }
}