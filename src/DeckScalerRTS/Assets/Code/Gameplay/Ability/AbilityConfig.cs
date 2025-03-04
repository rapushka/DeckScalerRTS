using System;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class AbilityConfig
    {
        [field: SerializeField] public AbilityUseTargetType TargetType { get; private set; }

        [field: SerializeField] public float BaseValue { get; private set; }
        [field: SerializeField] public float Range     { get; private set; }
        [field: SerializeField] public float Cooldown  { get; private set; }
    }
}