using Entitas.Generic;

namespace DeckScaler
{
    public sealed class GameplayFeature : Feature
    {
        public GameplayFeature()
            : base(nameof(GameplayFeature))
        {
#region Initialize
            Add(new InitializeInputSystem());
            Add(new InitializeSelectionRectViewSystem());
            Add(new TestSpawnUnitSystem());
#endregion

#region Update
#region Input
            Add(new EmitMousePositionSystem());
            Add(new EmitMouseOrdersSystem());

            Add(new ReadClicksOnEntitySystem());
            Add(new StartDraggingCameraSystem());
            Add(new DragCameraSystem());
#endregion

            Add(new TickLooseTimersSystem());

#region Selection
            Add(new OnUnitClickedSystem());

#region Area
            Add(new StartSelectionSystem());
            Add(new CalculateSelectionRectSystem());
            Add(new DrawSelectionAreaViewSystem());

            Add(new OnSelectionEndedSystem());
            Add(new SelectUnitsInRectSystem());
            Add(new StopSelectionSystem());
#endregion

            Add(new UnselectAllUnitsSystem());
            Add(new SelectUnitsSystem());

            Add(new CleanupSelectionEndedSystem());
#endregion

#region Orders
            Add(new EmitUnitOrderSystem());
            Add(new HandleAttackUnitOrderSystem());
            Add(new HandleMoveToPositionOrderSystem());
            Add(new CreateOrderTargetViewSystem());

            Add(new MoveToPositionSystem());

            Add(new TriggerAutoAttackSystem());
            Add(new FlipAutoAttackOnSelectedUnitsSystem());
            Add(new RemoveOpponentIfOutOfRangeSystem());

            Add(new MoveToOpponentSystem());
#endregion

#region Ability
            Add(new CoolDownAbilitiesSystem());
            Add(new UseCooledDownAbilitiesOnOpponentSystem());

            Add(new ApplyDealDamageAffectsSystem());
            Add(new PlayUnitAttackAnimationSystem());

            Add(new ResetUsedAbilitiesSystem());
#endregion

#region Health
            Add(new MarkDeadUnitsWithZeroHpSystem());

#region Death
            Add(new CleanupDeadOpponentsSystem());
            Add(new OnAnyFellaDiedStartLooseTimerSystem());

            Add(new DestroyDeadUnitsSystem());
            Add(new FreeTentOnAllEnemiesDeadSystem());
#endregion
#endregion

#region Selection UI
            Add(new InitSelectionUiSystem());

            Add(new HideSelectionUiIfNoUnitsSelectedSystem());
            Add(new UpdateSelectionUiPartVisibilityOnUnitsSelectedSystem());

            // single
            Add(new LoadSingleSelectedUnitPortraitSystem());
            Add(new UpdateSingleSelectedUnitHealthBarSystem());
            Add(new UpdateSingleSelectedUnitAutoAttackStateSystem());

            // multiple
            Add(new UpdateMultipleSelectedUnitsHealthBarSystem());
            Add(new UpdateMultipleSelectedUnitsAutoAttackStateSystem());

            Add(new ShowSelectionUiPartSystem());
#endregion
#endregion

#region Cleanups
            Add(new OnGameLostSystem());
            Add(new OnGameLostSystem());
            Add(new DestroyEntitiesAfterDelaySystem());

            Add(new DestroyWithChildrenSystem());
            Add(new DestroyEntitiesSystem());
#endregion

#region Boilerplate
            var contexts = Contexts.Instance;
            Add(new SelfEventSystem<GameScope, HeadSprite>(contexts));
            Add(new SelfFlagEventSystem<GameScope, SelectedUnit>(contexts));
            Add(new SelfEventSystem<GameScope, WorldPosition>(contexts));
            Add(new AnyEventSystem<GameScope, MaxHealth>(contexts));
            Add(new AnyEventSystem<GameScope, Health>(contexts));
            Add(new SelfFlagEventSystem<GameScope, OnEnemySide>(contexts));

            Add(new RemoveComponentsSystem<GameScope, Clicked>(contexts));
#endregion
        }
    }
}