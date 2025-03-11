using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class MultipleUnitsUiView : BaseUnitView
    {
        private AutoAttackState _autoAttackState;

        public override float           HealthPercent   => 0;                // TODO:
        public override string          HealthText      => "0";              // TODO:
        public override AutoAttackState AutoAttackState => _autoAttackState; // TODO:

        public void SetUnits(IGroup<Entity<GameScope>> units)
        {
            // TODO: implement
        }

        public override void OnAutoAttackButtonClick()
        {
            // TODO: implement
        }

        public override void Dispose()
        {
            // TODO: implement
        }
    }
}