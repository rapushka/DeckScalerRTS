using System;
using SmartIdTable;
using UnityEngine;

namespace DeckScaler
{
    /// Lil Attribute for cases where I need <c>UnitIDRef</c> but can't use it:)
    [AttributeUsage(AttributeTargets.Field)]
    public class UnitIDAttribute : PropertyAttribute { }

    /// Lil Attribute for cases where I need <c>ItemIDRef</c> but can't use it:)
    [AttributeUsage(AttributeTargets.Field)]
    public class ItemIDAttribute : PropertyAttribute { }

    [Serializable]
    public struct UnitIDRef : IEquatable<UnitIDRef>
    {
        [IdRef(startsWith: Constants.TableID.Units)]
        public string Value;

        public static implicit operator UnitIDRef(string unitID) => new() { Value = unitID };
        public static implicit operator string(UnitIDRef unitID) => unitID.Value;

        public static bool operator ==(UnitIDRef lhs, UnitIDRef rhs) => lhs.Value == rhs.Value;
        public static bool operator !=(UnitIDRef lhs, UnitIDRef rhs) => !(lhs == rhs);

#region Boilerplate
        public bool Equals(UnitIDRef other) => Value == other.Value;

        public override bool Equals(object obj) => obj is UnitIDRef other && Equals(other);

        public override int GetHashCode() => (Value != null ? Value.GetHashCode() : 0);
#endregion

        public override string ToString() => Value;
    }

    [Serializable]
    public struct ItemIDRef : IEquatable<ItemIDRef>
    {
        [IdRef(startsWith: Constants.TableID.Items)]
        public string Value;

        public static implicit operator ItemIDRef(string itemID) => new() { Value = itemID };
        public static implicit operator string(ItemIDRef itemID) => itemID.Value;

        public static bool operator ==(ItemIDRef lhs, ItemIDRef rhs) => lhs.Value == rhs.Value;
        public static bool operator !=(ItemIDRef lhs, ItemIDRef rhs) => !(lhs == rhs);

#region Boilerplate
        public bool Equals(ItemIDRef other) => Value == other.Value;

        public override bool Equals(object obj) => obj is ItemIDRef other && Equals(other);

        public override int GetHashCode() => (Value != null ? Value.GetHashCode() : 0);
#endregion

        public override string ToString() => Value;
    }
}