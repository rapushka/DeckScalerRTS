using System;

namespace DeckScaler
{
    public static class UnitsSelectionUiExtensions
    {
        public static void SwitchUnitsCount(this int unitCount, Action onSingle, Action onMultiple)
            => unitCount.SwitchUnitsCount(onSingle, onMultiple, () => throw new("Unreachable"));

        public static void SwitchUnitsCount(this int unitCount, Action onSingle, Action onMultiple, Action onNone)
        {
            if (unitCount == 0)
                onNone?.Invoke();
            else if (unitCount == 1)
                onSingle.Invoke();
            else
                onMultiple.Invoke();
        }
    }
}