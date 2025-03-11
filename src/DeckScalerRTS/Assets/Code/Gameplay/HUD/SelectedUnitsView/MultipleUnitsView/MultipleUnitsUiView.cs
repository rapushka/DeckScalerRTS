using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class MultipleUnitsUiView : BaseUnitView
    {
        private List<Entity<GameScope>> _retainedUnits;
        private Entity<GameScope>[] _allSelectedUnits;

        public override HpData HpData => GetMinHealth().WithFormat("min HP: {0}");

        public override AutoAttackState AutoAttackState
        {
            get
            {
                var commonState = (AutoAttackState?)null;

                foreach (var unit in _retainedUnits)
                {
                    var state = unit.GetAutoAttackState();
                    commonState ??= state;

                    if (commonState != state)
                        return AutoAttackState.Mixed;
                }

                return commonState!.Value;
            }
        }

        public void SetUnits(IGroup<Entity<GameScope>> units)
        {
            _allSelectedUnits = units.GetEntities();
            _retainedUnits = _allSelectedUnits.ToList();
            ForEachUnit(u => u.Retain(this));

            // TODO: implement grid units view
        }

        public override void OnAutoAttackButtonClick()
        {
            var commonState = AutoAttackState;
            Action<Entity<GameScope>> changeState = commonState is AutoAttackState.Mixed
                ? AllUnitToAutoAttack
                : FlipAutoAttackState;

            ForEachUnit(changeState);
            return;

            void AllUnitToAutoAttack(Entity<GameScope> unit) => unit.Is<InAutoAttackState>(true);

            void FlipAutoAttackState(Entity<GameScope> unit)
                => unit.Is<InAutoAttackState>(!unit.Is<InAutoAttackState>());
        }

        public override void Dispose()
        {
            ForEachUnit(u => u.Release(this));
            _retainedUnits = null;
        }

        public override void UpdateValues()
        {
            FlushInvalidUnits();
        }

        private void FlushInvalidUnits()
        {
            foreach (var unit in _allSelectedUnits)
            {
                if (!unit.IsAlive())
                {
                    unit.Release(this);
                    _retainedUnits.Remove(unit);
                }
            }

            if (!_retainedUnits.Any())
                ForceHide();
        }

        private void ForEachUnit(Action<Entity<GameScope>> action)
        {
            if (_retainedUnits is null)
                return;

            foreach (var unit in _retainedUnits)
                action.Invoke(unit);
        }

        private HpData GetMinHealth()
        {
            var minHp = (HpData?)null;

            foreach (var unit in _retainedUnits)
            {
                var health = unit.GetOrDefault<Health, float>();

                if (minHp is null || minHp.Value.Health > health)
                    minHp = unit.GetHpData();
            }

            return minHp!.Value;
        }
    }
}