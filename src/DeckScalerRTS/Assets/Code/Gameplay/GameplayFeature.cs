using DeckScaler.Scope;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class GameplayFeature : Feature
    {
        public GameplayFeature()
            : base(nameof(GameplayFeature))
        {
            // ---
            // # Initialize
            Add(new InitializeInputSystem());
            Add(new TestSpawnUnitSystem());

            // ---
            // # Update
            Add(new EmitMousePositionSystem());
            Add(new EmitMouseOrdersSystem());
            Add(new ReadClicksOnEntitySystem());
            Add(new OnDragCameraStartedSystem());
            Add(new DragCameraSystem());

            // selection
            Add(new OnUnitClickedSystem());
            Add(new UnselectAllUnitsSystem());
            Add(new SelectUnitsSystem());

            // orders
            Add(new OrderMoveSystem());
            Add(new CalculatePathToMoveOrderSystem());

            // ---
            // # Cleanups
            Add(new DestroyEntitiesSystem());

            // ---
            // # Boilerplate
            var contexts = Contexts.Instance;
            Add(new SelfEventSystem<GameScope, HeadSprite>(contexts));
            Add(new SelfFlagEventSystem<GameScope, SelectedUnit>(contexts));
            Add(new SelfEventSystem<GameScope, WorldPosition>(contexts));
            Add(new RemoveComponentsSystem<GameScope, Clicked>(contexts));
        }
    }
}