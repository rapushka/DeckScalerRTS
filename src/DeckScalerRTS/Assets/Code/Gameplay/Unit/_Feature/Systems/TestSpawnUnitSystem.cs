using DeckScaler.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class TestSpawnUnitSystem : IInitializeSystem
    {
        private static ScopeContext<Game> Context => Contexts.Instance.Get<Game>();

        public void Initialize()
        {
            var viewPrefab = Resources.Load<EntityBehaviour>("Tmp/Unit");

            var view = Object.Instantiate(viewPrefab);
            var entity = Context.CreateEntity()
                .Add<UnitID, string>("crook");

            view.Register(entity);
            entity.Get<SpriteView>().Value.sprite = Resources.Load<Sprite>("Tmp/crook_head_small");
        }
    }
}