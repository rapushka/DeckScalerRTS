using System;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class EconomyConfig
    {
        [field: SerializeField] public int MoneyAtStart          { get; private set; }
        [field: SerializeField] public int MoneyGainForFreedTent { get; private set; }

        [field: SerializeField] public ShopConfig Shop { get; private set; }

        private static IRandomService Random => ServiceLocator.Resolve<IRandomService>();

        [Serializable]
        public class ShopConfig
        {
            [SerializeField] private UnitIDRef[] _possibleUnitsInShop;

            [field: SerializeField] public EntityBehaviour ViewPrefab { get; private set; }
            [field: SerializeField] public int             UnitSlots  { get; private set; } = 2;

            public UnitIDRef IssueRandomUnit() => Random.SelectRandom(_possibleUnitsInShop);
        }
    }
}