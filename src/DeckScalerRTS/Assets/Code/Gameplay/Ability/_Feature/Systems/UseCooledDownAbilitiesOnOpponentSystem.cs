using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class UseCooledDownAbilitiesOnOpponentSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _abilities
            = GroupBuilder<GameScope>
                .With<AbilityOf>()
                .And<CooldownUp>()
                .And<UseOnOpponent>()
                .Build();

        private static IAffectFactory AffectFactory => ServiceLocator.Resolve<IAffectFactory>();

        public void Execute()
        {
            foreach (var ability in _abilities)
            {
                var owner = ability.Get<AbilityOf, EntityID>().GetEntity();

                if (!owner.TryGet<Opponent, EntityID>(out var opponentID))
                    continue;

                var opponent = opponentID.GetEntity();
                var affectConfig = ability.Get<AbilityAffectConfig, AffectConfig>();
                AffectFactory.Create(affectConfig, owner, opponent);

                ability.Is<Used>(true);
            }
        }
    }
}