namespace DeckScaler
{
    public class Modifier
    {
        public float Addition   { get; set; }
        public float Multiplier { get; set; } = 1f;

        public float Apply(float baseValue) => (baseValue + Addition) * Multiplier;

        public override string ToString() => $"(+{Addition} *{Multiplier})";
    }

    public static class ModifierExtensions
    {
        public static float Modify(this float baseValue, Modifier modifier)
            => modifier.Apply(baseValue);
    }
}