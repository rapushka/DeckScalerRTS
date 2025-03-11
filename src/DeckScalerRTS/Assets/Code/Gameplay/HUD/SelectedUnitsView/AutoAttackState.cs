using Entitas.Generic;

namespace DeckScaler
{
    public enum AutoAttackState
    {
        Unknown = 0,
        Attacking = 1,
        Ignore = 2,
        Mixed = 3,
    }

    public static class AutoAttackStateExtensions
    {
        public static AutoAttackState GetAutoAttackState(this Entity<GameScope> @this)
            => @this.Is<InAutoAttackState>()
                ? AutoAttackState.Attacking
                : AutoAttackState.Ignore;
    }
}