using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class ApplyGainMoneyAffectsSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _affects
            = GroupBuilder<GameScope>
                .With<Affect>()
                .And<GainMoneyAffect>()
                .And<AffectValue>()
                .And<OnPlayerSide>()
                .Build();

        public void Execute()
        {
            foreach (var affect in _affects)
            {
                var affectValue = affect.Get<AffectValue, float>();
                MoneyUtils.GainMoney((int)affectValue);
            }
        }
    }
}