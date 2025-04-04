using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckScaler
{
    public class TypeStats<T>
    {
        protected readonly Dictionary<StatID, T> Dictionary;

        protected TypeStats(Dictionary<StatID, T> dictionary) => Dictionary = dictionary;

        public T this[StatID id]
        {
            get => Dictionary[id];
            set => Dictionary[id] = value;
        }

        protected static Dictionary<StatID, T> EmptyDictionary(Func<T> create)
            => Enum.GetValues(typeof(StatID))
                .Cast<StatID>()
                .Except(new[] { StatID.Unknown })
                .ToDictionary(x => x, _ => create.Invoke());

        public override string ToString() => Dictionary.JoinToString();
    }

    public class Stats : TypeStats<float>
    {
        private Stats(Dictionary<StatID, float> dictionary) : base(dictionary) { }

        public static Stats Empty() => new(EmptyDictionary(() => 0));

        public Stats With(StatID key, float value)
        {
            this[key] = value;
            return this;
        }
    }

    public class StatMods : TypeStats<Modifier>
    {
        private StatMods(Dictionary<StatID, Modifier> dictionary) : base(dictionary) { }

        public static StatMods Empty() => new(EmptyDictionary(() => new()));

        public StatMods Reset()
        {
            foreach (var (_, modifier) in Dictionary)
                modifier.Reset();

            return this;
        }
    }
}