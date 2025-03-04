using System.Collections.Generic;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class HandleMoveToPositionOrderSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _events
            = GroupBuilder<GameScope>
                .With<OrderOnPositionEvent>()
                .And<OrderListener>()
                .Without<Processed>()
                .Build();

        private readonly List<Entity<GameScope>> _buffer = new(16);

        public void Execute()
        {
            foreach (var e in _events.GetEntities(_buffer))
            {
                var targetPosition = e.Get<OrderOnPositionEvent, Vector2>();

                var listener = e.Get<OrderListener, EntityID>().GetEntity();
                listener
                    .Is<InAutoAttackState>(false)
                    .Set<MoveToPosition, Vector2>(targetPosition)
                    .RemoveSafely<Opponent>()
                    ;

                e.Is<Processed>(true);
                break;
            }
        }
    }
}