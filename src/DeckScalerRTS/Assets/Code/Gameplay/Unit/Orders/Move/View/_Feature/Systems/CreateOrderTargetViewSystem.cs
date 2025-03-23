using DG.Tweening;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class CreateOrderTargetViewSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _events
            = GroupBuilder<GameScope>
                .With<OrderOnPositionEvent>()
                .And<OrderListener>()
                .And<Processed>()
                .Build();

        private static IViewFactory ViewFactory => ServiceLocator.Resolve<IViewFactory>();

        private static UnitsConfig.UiConfig Config => ServiceLocator.Resolve<IGameConfig>().Units.UI;

        public void Execute()
        {
            foreach (var e in _events)
            {
                var isAttack = e.Is<ProcessedAsAttackOrder>();

                var targetPosition = isAttack
                    ? GetOpponentPosition(e)
                    : e.Get<OrderOnPositionEvent, Vector2>();

                var view = ViewFactory.CreateInWorld(Config.TargetViewPrefab, targetPosition).Entity;
                var animation = (BaseEntityAnimation)view.Get<Animator>().Value;

                var tween = animation.Play(e);
                view.Add<DestroyAfterDelay, Timer>(new(tween.Duration()));
            }
        }

        private static Vector2 GetOpponentPosition(Entity<GameScope> eventEntity)
            => eventEntity.Get<OrderListener, EntityID>().GetEntity()
                .Get<Opponent, EntityID>().GetEntity()
                .Get<WorldPosition, Vector2>();
    }
}