using System.Collections.Generic;
using Entitas.Generic;
using Entitas.VisualDebugging.Unity;
using UnityEngine;
using EntityDebugger = Entitas.VisualDebugging.Unity.EntityBehaviour;

namespace DeckScaler
{
    public class EntityParenthoodDebugger
    {
        // key: entity, value: its parent
        private readonly Dictionary<EntityID, EntityID> _processedEntities = new();

        private ContextObserverBehaviour ContextBehaviour { get; set; }

        private IEnumerable<EntityDebugger> EntityDebuggers
            => ContextBehaviour.GetComponentsInChildren<EntityDebugger>();

        public void Initialize()
        {
            var contexts = Object.FindObjectsByType<ContextObserverBehaviour>(FindObjectsSortMode.None);

            foreach (var context in contexts)
            {
                // if (context.contextObserver.context is Context<Entity<GameScope>>)
                if (context.name.Contains(nameof(GameScope)))
                    ContextBehaviour = context;
            }
        }

        public void OnUpdate(float _)
        {
            if (ContextBehaviour is null)
                return;

            foreach (Transform child in ContextBehaviour.transform)
            {
                if (TryGetEntity(child.gameObject, out var entity) && entity.isEnabled)
                    HandleEntity(entity, child);
            }
        }

        private bool TryGetEntity(GameObject gameObject, out Entity<GameScope> entity)
        {
            var isEntityBehaviour = gameObject.TryGetComponent<EntityDebugger>(out var entityBehaviour);
            entity = isEntityBehaviour ? (Entity<GameScope>)entityBehaviour.entity : null;
            return isEntityBehaviour;
        }

        private void HandleEntity(Entity<GameScope> entity, Transform childDebugger)
        {
            var entityID = entity.ID();

            if (!entity.IsAlive() || !entity.TryGet<ChildOf, EntityID>(out var parentID))
            {
                _processedEntities.Remove(entityID);
                return;
            }

            if (_processedEntities.TryGetValue(entityID, out var cashedParentID)
                && cashedParentID == parentID)
                return;

            foreach (var debugger in EntityDebuggers)
            {
                var parent = (Entity<GameScope>)debugger.entity;

                if (parent.isEnabled && parentID == parent.ID())
                {
                    childDebugger.SetParent(debugger.transform);
                    _processedEntities[entityID] = parent.ID();
                }
            }
        }
    }
}