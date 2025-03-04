using Entitas.Generic;

namespace DeckScaler
{
    public static class DebugNameExtensions
    {
        public static string GetName(this Entity<GameScope> @this)
            => @this.ToString<DebugName, string>(defaultValue: "e");
    }
}