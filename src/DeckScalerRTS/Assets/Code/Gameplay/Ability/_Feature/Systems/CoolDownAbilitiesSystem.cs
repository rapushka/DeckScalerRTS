using System.Collections.Generic;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class CoolDownAbilitiesSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _abilities
            = GroupBuilder<GameScope>
                .With<AbilityOwner>()
                .And<BaseCooldown>()
                .Without<CooldownUp>()
                .Build();

        private static ITimeService Time => ServiceLocator.Resolve<ITimeService>();

        private readonly List<Entity<GameScope>> _buffer = new(16);

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                var cooldownTimer = ability.Get<CooldownTimer, Timer>();
                cooldownTimer.Tick(Time.Delta);

                if (cooldownTimer.IsElapsed)
                    ability.Is<CooldownUp>(true);
            }
        }
    }
}