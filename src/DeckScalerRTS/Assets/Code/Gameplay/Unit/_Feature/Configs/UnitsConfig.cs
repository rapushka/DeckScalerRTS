using System;
using System.Linq;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class UnitsConfig
    {
        [field: SerializeField] public  EntityBehaviour UnitViewPrefab { get; private set; }
        [field: SerializeField] private UnitConfig[]    Units          { get; set; }
        [field: SerializeField] public  CommonBalance   Common         { get; private set; }
        [field: SerializeField] public  UiConfig        UI             { get; private set; }

        public UnitConfig GetConfig(UnitIDRef id) => Units.Single(c => c.ID == id);

        [Serializable]
        public class CommonBalance
        {
            [field: SerializeField] public float AttackTriggerRadius { get; private set; }
        }

        [Serializable]
        public class UiConfig
        {
            [field: SerializeField] public EntityBehaviour TargetViewPrefab    { get; private set; }
            [field: SerializeField] public EntityBehaviour SelectionViewPrefab { get; private set; }
        }
    }
}