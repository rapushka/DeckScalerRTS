using System;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class Modifier
    {
        [field: SerializeField] public float Addition   { get; private set; }
        [field: SerializeField] public float Multiplier { get; private set; }

        public Modifier(float addition = 0f, float multiplier = 1f)
        {
            Addition = addition;
            Multiplier = multiplier;
        }

        public float Apply(float baseValue) => (baseValue + Addition) * Multiplier;

        public void Reset()
        {
            Addition = 1f;
            Multiplier = 0f;
        }

        public void Combine(Modifier other)
        {
            Addition += other.Addition;
            Multiplier *= other.Multiplier;
        }

        public override string ToString() => $"(+{Addition} *{Multiplier})";
    }

    public static class ModifierExtensions
    {
        public static float Modify(this float baseValue, Modifier modifier)
            => modifier.Apply(baseValue);
    }
}