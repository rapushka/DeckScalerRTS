using Entitas;
using Entitas.Generic;
using UnityEngine;

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

        public void Execute()
        {
            foreach (var ability in _abilities)
            {
                var owner = ability.Get<AbilityOf, EntityID>().GetEntity();

                if (!owner.TryGet<Opponent, EntityID>(out var opponentID))
                    continue;

                Debug.Log($"TODO: ability {ability} used on {opponentID.GetEntity()} by {owner}");
                ability.Is<Used>(true);
            }
        }
    }
}