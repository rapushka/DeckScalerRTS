using System;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class DebugSettings
    {
        [field: SerializeField] public bool EnableEntityParenthoodDebugger { get; private set; }
    }
}