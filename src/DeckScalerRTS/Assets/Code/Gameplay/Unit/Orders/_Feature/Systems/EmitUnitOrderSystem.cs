using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class EmitUnitOrderSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<InputScope>> _inputs
            = GroupBuilder<InputScope>
                .With<PlayerInput>()
                .And<JustClickedOrder>()
                .And<MouseWorldPosition>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _selectedUnits
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<SelectedUnit>()
                .And<OnPlayerSide>()
                .Build();

        public void Execute()
        {
            foreach (var mouse in _inputs)
            foreach (var unit in _selectedUnits)
            {
                var mouseWorldPosition = mouse.Get<MouseWorldPosition, Vector2>();
                CreateEntity.OneFrame()
                    .Add<OrderOnPositionEvent, Vector2>(mouseWorldPosition)
                    .Add<OrderListener, EntityID>(unit.ID())
                    ;
            }
        }
    }
}