using System.Collections.Generic;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class ResetUsedAbilitiesSystem : ICleanupSystem
    {
        private readonly IGroup<Entity<GameScope>> _abilities
            = GroupBuilder<GameScope>
                .With<AbilityOf>()
                .And<Used>()
                .And<BaseCooldown>()
                .And<CooldownTimer>()
                .And<CooldownUp>()
                .Build();

        private readonly List<Entity<GameScope>> _buffer = new(16);

        public void Cleanup()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                var baseCooldown = ability.Get<BaseCooldown, float>();

                ability
                    .Set<CooldownTimer, Timer>(new(baseCooldown))
                    .Is<CooldownUp>(false)
                    ;
            }
        }
    }
}