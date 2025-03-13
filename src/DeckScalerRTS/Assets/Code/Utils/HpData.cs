using Entitas.Generic;

namespace DeckScaler
{
    public struct HpData
    {
        private string _format;

        public HpData(float health, float maxHealth)
        {
            Health = health;
            MaxHealth = maxHealth;

            _format = "{0}/{1}";
        }

        public float Health    { get; }
        public float MaxHealth { get; }

        public float NormalizedPercent => MaxHealth is 0 ? 0 : Health / MaxHealth;

        public static HpData Empty()
            => new HpData().WithFormat(string.Empty);

        public HpData WithFormat(string newFormat)
        {
            _format = newFormat;
            return this;
        }

        public override string ToString()
            => _format.Format(Health.FloorToInt(), MaxHealth.FloorToInt());
    }

    public static class HpDataExtensions
    {
        public static HpData GetHpData(this Entity<GameScope> @this)
        {
            var health = @this.Get<Health, float>();
            var maxHealth = @this.Get<MaxHealth, float>();

            return new(health, maxHealth);
        }
    }
}