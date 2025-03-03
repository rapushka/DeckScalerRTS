using DeckScaler.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class LogClickedUnitSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _clickedUnits
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<Clicked>()
                .Build();

        public void Execute()
        {
            foreach (var unit in _clickedUnits)
            {
                Debug.Log($"{unit} was just clicked");
            }
        }
    }
}