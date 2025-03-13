using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class FlipAutoAttackOnSelectedUnitsSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _requests
            = GroupBuilder<GameScope>
                .With<FlipSelectedUnitAttackStateEvent>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _selectedUnits
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<SelectedUnit>()
                .Build();

        public void Execute()
        {
            foreach (var _ in _requests)
            {
                var previousState = _selectedUnits.count.SwitchUnitsCount(
                    onSingle: SwapSingle,
                    onMultiple: _selectedUnits.GetCommonAutoAttackState
                );
                var newState = previousState.Flip();

                foreach (var unit in _selectedUnits)
                    unit.Is<InAutoAttackState>(newState is AutoAttackState.Attacking);
            }
        }

        private AutoAttackState SwapSingle()
        {
            var singleUnit = _selectedUnits.GetSingleEntity();
            return singleUnit.GetAutoAttackState();
        }
    }
}