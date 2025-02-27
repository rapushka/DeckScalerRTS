using DeckScaler.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class TestSpawnUnitSystem : IInitializeSystem
    {
        private static ScopeContext<Game> Context => Contexts.Instance.Get<Game>();

        private static IGameConfig Configs => ServiceLocator.Resolve<IGameConfig>();

        public void Initialize()
        {
            var id = Configs.TestUnitID;

            var view = Object.Instantiate(Configs.Units.UnitViewPrefab);
            var entity = Context.CreateEntity()
                .Add<UnitID, string>(id);

            view.Register(entity);
            entity.Get<SpriteView>().Value.sprite = Configs.Units.GetConfig(id).Head;
        }
    }
}