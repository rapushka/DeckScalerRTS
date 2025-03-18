using System;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class EconomyConfig
    {
        [field: SerializeField] public int MoneyAtStart          { get; private set; }
        [field: SerializeField] public int MoneyGainForFreedTent { get; private set; }
    }
}