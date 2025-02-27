using System;
using SmartIdTable;

namespace DeckScaler
{
    [Serializable]
    public struct UnitIDRef
    {
        [IdRef(startsWith: Constants.TableID.Units)]
        public string Value;

        public static implicit operator UnitIDRef(string unitID) => new() { Value = unitID };
        public static implicit operator string(UnitIDRef unitID) => unitID.Value;

        public static bool operator ==(UnitIDRef lhs, UnitIDRef rhs) => lhs.Value == rhs.Value;
        public static bool operator !=(UnitIDRef lhs, UnitIDRef rhs) => !(lhs == rhs);
    }
}