using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class ModifiersSetup
    {
        [SerializeField] private Entry[] _modifiers;

        public IEnumerable<(StatID, Modifier)> Modifiers => _modifiers.Select(x => (x.Stat, x.Modifier));

        public StatMods ToStats()
        {
            var modifiers = StatMods.Empty();
            foreach (var modifier in _modifiers)
                modifiers.Set(modifier.Stat, modifier.Modifier);

            return modifiers;
        }

        [Serializable]
        private struct Entry
        {
            public StatID Stat;
            public Modifier Modifier;
        }
    }
}