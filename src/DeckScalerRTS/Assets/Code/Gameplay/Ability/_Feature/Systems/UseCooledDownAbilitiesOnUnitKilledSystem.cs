using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class UseCooledDownAbilitiesOnUnitKilledSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _abilities
            = GroupBuilder<GameScope>
                .With<AbilityOwner>()
                .And<CooldownUp>()
                .And<CastWhenKilledUnit>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _deadUnits
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<Dead>()
                .And<LastHitFrom>()
                .Build();

        private static IAffectFactory AffectFactory => ServiceLocator.Resolve<IAffectFactory>();

        public void Execute()
        {
            foreach (var ability in _abilities)
            foreach (var deadUnit in _deadUnits)
            {
                var ownerID = ability.Get<AbilityOwner, EntityID>();
                var owner = ownerID.GetEntity();

                if (!owner.Is<OnPlayerSide>()
                    || !deadUnit.TryGet<LastHitFrom>(out var lastAttacker)
                    || lastAttacker.Value != ownerID)
                    continue;

                var affectConfig = ability.Get<AbilityAffectConfig, AffectConfig>();
                AffectFactory.Create(affectConfig, owner);

                ability.Is<Used>(true);
            }
        }
    }
}