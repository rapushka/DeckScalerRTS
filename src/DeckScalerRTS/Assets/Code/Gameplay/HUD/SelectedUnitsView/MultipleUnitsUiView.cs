using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class MultipleUnitsUiView : BaseUnitView
    {
        private int _maxHealth;
        private int _health;
        private AutoAttackState _autoAttackState;

        public override int MaxHealth => _maxHealth;
        public override int Health    => _health;

        public override AutoAttackState AutoAttackState => _autoAttackState;

        public void SetUnits(IGroup<Entity<GameScope>> units)
        {
            throw new System.NotImplementedException();
        }

        public override void OnAutoAttackButtonClick()
        {
            throw new System.NotImplementedException();
        }
    }
}