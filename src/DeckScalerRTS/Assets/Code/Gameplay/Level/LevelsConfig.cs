using System;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class LevelsConfig
    {
        [field: SerializeField] public EntityBehaviour TentView { get; private set; }
    }
}