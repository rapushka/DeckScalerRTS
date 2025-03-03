using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class CreateOrderTargetViewSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<InputScope>> _inputs
            = GroupBuilder<InputScope>
                .With<PlayerInput>()
                .And<JustClickedOrder>()
                .And<MouseWorldPosition>()
                .Build();

        private static IEntityBehaviourFactory Factory => ServiceLocator.Resolve<IEntityBehaviourFactory>();

        public void Execute()
        {
            foreach (var mouse in _inputs)
            {
                var mouseWorldPosition = mouse.Get<MouseWorldPosition, Vector2>();

                var view = Factory.CreateOrderView(mouseWorldPosition);
                var animation = view.GetComponent<OrderTargetViewAnimation>();
                view.Entity.Add<DestroyAfterDelay, Timer>(new(animation.WholeAnimationDuration));

                animation.Play();
            }
        }
    }
}