using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class DestroyEntitiesAfterDelaySystem : ICleanupSystem
    {
        private readonly IGroup<Entity<GameScope>> _entities
            = GroupBuilder<GameScope>
                .With<DestroyAfterDelay>()
                .Build();

        private static ITimeService Time => ServiceLocator.Resolve<ITimeService>();

        public void Cleanup()
        {
            foreach (var entity in _entities)
            {
                var timer = entity.Get<DestroyAfterDelay, Timer>();
                timer.Tick(Time.Delta);

                if (timer.IsElapsed)
                    entity.Add<Destroy>();
            }
        }
    }
}