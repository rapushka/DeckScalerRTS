using Entitas.Generic;

namespace DeckScaler
{
    public static class CustomIndexes
    {
        public static void Initialize()
        {
            new UnitInventorySlotPrimaryIndex(Contexts.Instance.Get<GameScope>()).Initialize();
        }
    }
}