using System;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class AffectConfig
    {
        [field: SerializeField] public float      Value  { get; private set; }
        [field: SerializeField] public AffectType Type { get; private set; }
    }
}