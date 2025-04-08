namespace EnlitGames.ScriptableObjectTable
{
    internal static class ColumnNameExtensions
    {
        internal static string ToColumnName(this string source)
        {
            if (source is null)
                return source;

            if (!source.EndsWith("k__BackingField"))
                return source;

            var startIndex = source.IndexOf('<') + 1;
            var endIndex = source.IndexOf('>');

            if (startIndex > 0 && endIndex > startIndex)
                return source.Substring(startIndex, endIndex - startIndex);

            return source;
        }
    }
}