using System.Collections.Generic;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class HandlePickUpItemOrderSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _events
            = GroupBuilder<GameScope>
                .With<OrderOnPositionEvent>()
                .And<OrderListener>()
                .Without<Processed>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _items
            = GroupBuilder<GameScope>
                .With<ItemID>()
                .And<LyingOnGround>()
                .And<WorldPosition>()
                .And<Collider>()
                .Build();

        private readonly List<Entity<GameScope>> _buffer = new(16);

        public void Execute()
        {
            foreach (var e in _events.GetEntities(_buffer))
            foreach (var item in _items)
            {
                var targetPosition = e.Get<OrderOnPositionEvent, Vector2>();
                var itemCollider = item.Get<Collider>().Value;
                var isClickOnItem = itemCollider.OverlapPoint(targetPosition);

                if (!isClickOnItem)
                    continue;

                var listener = e.Get<OrderListener, EntityID>().GetEntity();

                if (!listener.Is<HasAnyFreeInventorySlot>())
                {
                    e.Is<Processed>(true)
                        .Is<ProcessedAsAttackOrder>(false) // in this case Unit just Ignores the order
                        ;

                    continue;
                }

                var itemPosition = item.Get<WorldPosition>().Value;

                listener
                    .Set<PickUpItemOrder, EntityID>(item.ID())
                    .Set<MoveToPosition, Vector2>(itemPosition)
                    .Is<InAutoAttackState>(false)
                    .RemoveSafely<Opponent>()
                    ;

                e.Is<Processed>(true)
                    .Is<ProcessedAsAttackOrder>(false)
                    ;

                break;
            }
        }
    }
}