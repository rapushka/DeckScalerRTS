using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class UseCooledDownAbilitiesOnOpponentSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _abilities
            = GroupBuilder<GameScope>
                .With<AbilityOwner>()
                .And<CooldownUp>()
                .And<CastOnOpponent>()
                .And<Range>()
                .Build();

        private static IAffectFactory AffectFactory => ServiceLocator.Resolve<IAffectFactory>();

        private static ITimeService TimeService => ServiceLocator.Resolve<ITimeService>();

        public void Execute()
        {
            if (TimeService.IsTimeStopped)
                return;

            foreach (var ability in _abilities)
            {
                var owner = ability.Get<AbilityOwner, EntityID>().GetEntity();

                if (!owner.TryGet<Opponent, EntityID>(out var opponentID))
                    continue;

                var opponent = opponentID.GetEntity();
                var opponentPosition = opponent.Get<WorldPosition, Vector2>();
                var ownerPosition = owner.Get<WorldPosition, Vector2>();

                var distance = opponentPosition.DistanceTo(ownerPosition);

                if (ability.Get<Range, float>() < distance)
                    continue;

                var affectConfig = ability.Get<AffectOnUsed, AffectConfig>();
                AffectFactory.Create(affectConfig, owner, opponent);

                ability.Is<Used>(true);
            }
        }
    }
}