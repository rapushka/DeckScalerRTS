using System;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public struct AffectConfig
    {
        [field: SerializeField] public float      Value { get; private set; }
        [field: SerializeField] public AffectType Type  { get; private set; }

        public override string ToString() => $"{Type}: {Value}";
    }
}