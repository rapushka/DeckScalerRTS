using System;

namespace DeckScaler
{
    public enum Side
    {
        Unknown = 0,
        Player = 1,
        Enemy = 2,
    }

    public static class SideExtensions
    {
        // ReSharper disable once SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
        // - this is EXACTLY the point of the whole "Unknown" option
        public static Side Flip(this Side @this)
            => @this switch
            {
                Side.Player => Side.Enemy,
                Side.Enemy  => Side.Player,
                _           => throw new ArgumentOutOfRangeException(nameof(@this), @this, null),
            };
    }
}