using System.Linq;
using System.Text;
using Entitas.Generic;

namespace DeckScaler
{
    public class UiEntityFormatter : EntityStringBuilderFormatter<UiScope>
    {
        protected override void BuildName(ref StringBuilder stringBuilder, in Entity<UiScope> entity)
        {
            var buffer = new[]
            {
                $"i{entity.creationIndex}",
                $"{entity.GetName()} |",
            };

            stringBuilder.AppendJoin(separator: "  ", buffer.Where(s => !s.IsEmpty()));
        }
    }
}