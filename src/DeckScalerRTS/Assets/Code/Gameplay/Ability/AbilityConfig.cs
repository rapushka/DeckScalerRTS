using System;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class AbilityConfig
    {
        [field: SerializeField] public AbilityTriggerType TargetType { get; private set; }
        [field: SerializeField] public float              Range      { get; private set; }
        [field: SerializeField] public float              Cooldown   { get; private set; }
        [field: SerializeField] public AffectConfig       Affect     { get; private set; }
    }
}