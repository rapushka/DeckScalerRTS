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
            Add(new InitializeSelectionRectViewSystem());
            Add(new TestSpawnUnitSystem());

            // #---
            // # Update
            Add(new EmitMousePositionSystem());
            Add(new EmitMouseOrdersSystem());

            Add(new ReadClicksOnEntitySystem());
            Add(new StartDraggingCameraSystem());
            Add(new DragCameraSystem());

            // ## Selection
            Add(new OnUnitClickedSystem());

            // selection area & view
            Add(new StartSelectionSystem());
            Add(new CalculateSelectionRectSystem());
            Add(new DrawSelectionAreaViewSystem());

            Add(new OnSelectionEndedSystem());
            Add(new SelectUnitsInRectSystem());
            Add(new StopSelectionSystem());

            Add(new UnselectAllUnitsSystem());
            Add(new SelectUnitsSystem());

            Add(new CleanupSelectionEndedSystem());
            // ##---

            // orders
            Add(new EmitUnitOrderSystem());
            Add(new HandleAttackUnitOrderSystem());
            Add(new HandleMoveToPositionOrderSystem());
            Add(new CreateOrderTargetViewSystem());

            Add(new MoveToPositionSystem());

            Add(new TriggerAutoAttackSystem());
            Add(new RemoveOpponentIfOutOfRangeSystem());

            Add(new MoveToOpponentSystem());

            // ability
            Add(new CoolDownAbilitiesSystem());
            Add(new UseCooledDownAbilitiesOnOpponentSystem());

            Add(new ApplyDealDamageAffectsSystem());
            Add(new PlayUnitAttackAnimationSystem());

            Add(new ResetUsedAbilitiesSystem());

            // health
            Add(new MarkDeadUnitsWithZeroHpSystem());

            Add(new CleanupDeadOpponentsSystem());
            Add(new OnAnyFellaDiedStartLooseTimerSystem());
            Add(new LooseSystem());

            Add(new DestroyDeadUnitsSystem());
            Add(new FreeTentOnAllEnemiesDeadSystem());

            // #---
            // # Cleanups
            Add(new DestroyEntitiesAfterDelaySystem());

            Add(new DestroyWithChildrenSystem());
            Add(new DestroyEntitiesSystem());

            // #---
            // # Boilerplate
            var contexts = Contexts.Instance;
            Add(new SelfEventSystem<GameScope, HeadSprite>(contexts));
            Add(new SelfFlagEventSystem<GameScope, SelectedUnit>(contexts));
            Add(new SelfEventSystem<GameScope, WorldPosition>(contexts));
            Add(new SelfEventSystem<GameScope, MaxHealth>(contexts));
            Add(new SelfEventSystem<GameScope, Health>(contexts));
            Add(new SelfFlagEventSystem<GameScope, OnEnemySide>(contexts));

            Add(new RemoveComponentsSystem<GameScope, Clicked>(contexts));
        }
    }
}