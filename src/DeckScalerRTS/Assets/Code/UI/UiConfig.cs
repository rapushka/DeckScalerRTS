using System;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class UiConfig
    {
        [field: SerializeField] public BasePage[] PagePrefabs { get; private set; }
    }
}