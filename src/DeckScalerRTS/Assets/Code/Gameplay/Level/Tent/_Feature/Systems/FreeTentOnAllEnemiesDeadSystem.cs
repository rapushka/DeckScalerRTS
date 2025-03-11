using System.Collections.Generic;
using System.Linq;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class FreeTentOnAllEnemiesDeadSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _deadEnemies
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<OnEnemySide>()
                .And<Dead>()
                .Build();

        private readonly List<Entity<GameScope>> _buffer = new(16);

        private static EntityIndex<GameScope, OnTent, EntityID> Index
            => Contexts.Instance.Get<GameScope>().GetIndex<OnTent, EntityID>();

        public void Execute()
        {
            foreach (var enemy in _deadEnemies.GetEntities(_buffer))
            {
                var tentID = enemy.Get<OnTent, EntityID>();
                var hasAnyAliveEnemy = Index.GetEntities(tentID).Any(e => e.IsAlive());

                if (!hasAnyAliveEnemy)
                {
                    var tent = tentID.GetEntity();
                    tent
                        .Is<OnEnemySide>(false)
                        .Set<OnSide, Side>(Side.Player)
                        ;
                }
            }
        }
    }
}