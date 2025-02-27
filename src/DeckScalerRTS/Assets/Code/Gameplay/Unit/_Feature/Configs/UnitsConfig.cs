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

        public UnitConfig GetConfig(UnitIDRef id) => Units.Single(c => c.ID == id);
    }
}