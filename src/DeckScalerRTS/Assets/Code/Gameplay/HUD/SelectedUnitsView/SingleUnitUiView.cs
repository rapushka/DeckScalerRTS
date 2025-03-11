using Entitas.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
    public class SingleUnitUiView : BaseUnitView
    {
        [SerializeField] private Image _portraitView;

        private Entity<GameScope> _unit;

        public override HpData HpData => new(Health, MaxHealth);

        private float MaxHealth => _unit.Get<MaxHealth, float>();
        private float Health    => _unit.Get<Health, float>();

        public override AutoAttackState AutoAttackState => _unit.GetAutoAttackState();

        private static UnitsConfig UnitsConfig => ServiceLocator.Resolve<IGameConfig>().Units;

        public void SetUnit(Entity<GameScope> unit)
        {
            _unit = unit;
            _unit.Retain(this);

            var id = _unit.Get<UnitID, UnitIDRef>();
            var unitConfig = UnitsConfig.GetConfig(id);

            _portraitView.sprite = unitConfig.Portrait;
        }

        public override void OnAutoAttackButtonClick()
        {
            var wasInAutoAttack = _unit.Is<InAutoAttackState>();
            _unit.Is<InAutoAttackState>(!wasInAutoAttack);
        }

        public override void UpdateValues()
        {
            if (_unit.IsAlive())
                return;

            Dispose();
            ForceHide();
        }

        public override void Dispose()
        {
            _unit?.Release(this);
            _unit = null;
        }
    }
}