using Entitas.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
    public class SingleUnitUiView : BaseUnitView
    {
        [SerializeField] private Image _portraitView;

        private int _maxHealth;
        private int _health;
        private AutoAttackState _autoAttackState;

        public override int MaxHealth => _maxHealth;
        public override int Health    => _health;

        public override AutoAttackState AutoAttackState => _autoAttackState;

        private static UnitsConfig UnitsConfig => ServiceLocator.Resolve<IGameConfig>().Units;

        public void SetUnit(Entity<GameScope> unit)
        {
            var id = unit.Get<UnitID, UnitIDRef>();
            var unitConfig = UnitsConfig.GetConfig(id);

            _portraitView.sprite = unitConfig.Portrait;

            _maxHealth = unit.Get<MaxHealth, float>().FloorToInt();
            _health = unit.Get<Health, float>().FloorToInt();

            _autoAttackState = unit.Is<InAutoAttackState>()
                ? AutoAttackState.Attacking
                : AutoAttackState.Ignore;
        }

        public override void OnAutoAttackButtonClick()
        {
            Debug.Log("TODO: change state");
        }
    }
}