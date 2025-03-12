using Entitas;
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

        public static AutoAttackState Flip(this AutoAttackState @this)
            // ReSharper disable once SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
            => @this switch
            {
                AutoAttackState.Attacking => AutoAttackState.Ignore,
                AutoAttackState.Ignore    => AutoAttackState.Attacking,
                AutoAttackState.Mixed     => AutoAttackState.Attacking,
                _                         => throw new("Can't flip other AutoAttack State"),
            };

        public static AutoAttackState GetCommonAutoAttackState(this IGroup<Entity<GameScope>> @this)
        {
            var commonState = (AutoAttackState?)null;

            foreach (var unit in @this)
            {
                var unitState = unit.GetAutoAttackState();
                commonState ??= unitState;

                if (commonState != unitState)
                    return AutoAttackState.Mixed;
            }

            return commonState ?? throw new("The group is empty");
        }
    }
}