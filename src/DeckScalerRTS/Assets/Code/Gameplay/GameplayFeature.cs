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
            Add(new GenerateLevelSystem());
#endregion

#region Update
#region Input
            Add(new EmitMousePositionSystem());
            Add(new EmitMouseOrdersSystem());

            Add(new ReadClicksOnEntitySystem());
            Add(new StartDraggingCameraSystem());
            Add(new DragCameraSystem());
            Add(new ZoomCameraSystem());
#endregion

            Add(new TickLooseTimersSystem());
            Add(new MarkDeadUnitsProcessed());

#region Selection
            Add(new SelectLeaderOnStartSystem());
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
            Add(new UseCooledDownAbilitiesOnUnitKilledSystem());

            Add(new ApplyDealDamageAffectsSystem());
            Add(new ApplyGainMoneyAffectsSystem());
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

#region HUD
            Add(new InitializeHudEntitySystem());

#region Money
            Add(new InitializePlayerMoneySystem());
            Add(new GainMoneyOnTentFreedSystem());

#region Shop
            Add(new UpdateItemWithPriceInShopAvailabilitySystem());

            Add(new RequestShopRestockOnRestockButtonClickedSystem());
            Add(new OnRestockIncreaseRestockPriceSystem());

            Add(new RestockShopsSystem());
            Add(new MakeStocksVisibleOnShopRestock());

            Add(new SendSpendMoneyOnItemBoughtSystem());
            Add(new OnBuyStockButtonClickedSystem());

            Add(new OnUnitJustPurchasedSystem());
#endregion

            Add(new GainMoneySystem());
            Add(new SpendMoneySystem());

            // view
            Add(new UpdatePlayerMoneySystem());
#endregion

#region Selection UI
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
#endregion

#region Cleanups
            Add(new RemoveComponentSystem<TentJustFreed>());
            Add(new RemoveComponentSystem<JustPurchased>());
            Add(new RemoveComponentSystem<Restock>());

            Add(new OnGameLostSystem());
            Add(new DestroyEntitiesAfterDelaySystem());

            Add(new DestroyWithChildrenSystem());
            Add(new DestroyEntitiesSystem());
#endregion

#region Boilerplate
            var contexts = Contexts.Instance;
            Add(new SelfEventSystem<GameScope, HeadSprite>(contexts));
            Add(new SelfEventSystem<GameScope, ItemSprite>(contexts));
            Add(new SelfFlagEventSystem<GameScope, SelectedUnit>(contexts));
            Add(new SelfEventSystem<GameScope, WorldPosition>(contexts));
            Add(new SelfEventSystem<GameScope, Price>(contexts));
            Add(new SelfEventSystem<GameScope, Visible>(contexts));
            Add(new SelfFlagEventSystem<GameScope, Available>(contexts));
            Add(new AnyEventSystem<GameScope, MaxHealth>(contexts)); // TODO: are these need to be Any??
            Add(new AnyEventSystem<GameScope, Health>(contexts));    // TODO: are these need to be Any??
            Add(new SelfFlagEventSystem<GameScope, OnEnemySide>(contexts));

            Add(new RemoveComponentsSystem<GameScope, Clicked>(contexts));
#endregion
        }
    }
}