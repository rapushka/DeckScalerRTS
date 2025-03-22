using System;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class AbilityConfig
    {
        [field: SerializeField] public AbilityTriggerType TriggerType { get; private set; }
        [field: SerializeField] public float              Range       { get; private set; }
        [field: SerializeField] public float              Cooldown    { get; private set; }
        [field: SerializeField] public AffectConfig       Affect      { get; private set; }

        public override string ToString()
            => $"target: {TriggerType}, "
                + $"range: {Range}, "
                + $"cd: {Cooldown}, "
                + $"affect: {{{Affect}}}";
    }
}