using System;

namespace DeckScaler
{
    public static class UnitsSelectionUiExtensions
    {
        public static void SwitchUnitsCount(this int unitCount, Action onSingle, Action onMultiple)
            => unitCount.SwitchUnitsCount(onSingle, onMultiple, () => throw new("Zero Selected Units is invalid here"));

        public static void SwitchUnitsCount(this int unitCount, Action onSingle, Action onMultiple, Action onNone)
        {
            if (unitCount == 0)
                onNone.Invoke();
            else if (unitCount == 1)
                onSingle.Invoke();
            else
                onMultiple.Invoke();
        }

        public static T SwitchUnitsCount<T>(this int unitCount, Func<T> onSingle, Func<T> onMultiple)
            => unitCount.SwitchUnitsCount(onSingle, onMultiple, () => throw new("Zero Selected Units is invalid here"));

        public static T SwitchUnitsCount<T>(this int unitCount, Func<T> onSingle, Func<T> onMultiple, Func<T> onNone)
            => unitCount switch
            {
                0 => onNone.Invoke(),
                1 => onSingle.Invoke(),
                _ => onMultiple.Invoke(),
            };
    }
}