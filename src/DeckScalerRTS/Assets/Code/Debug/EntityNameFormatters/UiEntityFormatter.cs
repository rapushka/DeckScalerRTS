using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class UiEntityFormatter : EntityStringBuilderFormatter<UiScope>
    {
        private readonly IGroup<Entity<GameScope>> _selectedUnits
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<SelectedUnit>()
                .Build();

        private readonly List<Entity<GameScope>> _buffer = new(64);

        protected override void BuildName(ref StringBuilder stringBuilder, in Entity<UiScope> entity)
        {
            var buffer = new[]
            {
                $"i{entity.creationIndex}",
                $"{entity.GetName()} |",

                // selected units UI
                ToStringSelectedUnits(entity),
            };

            stringBuilder.AppendJoin(separator: "  ", buffer.Where(s => !s.IsEmpty()));
        }

        private string ToStringSelectedUnits(in Entity<UiScope> entity)
            => entity.Has<SelectedUnitUi>()
                ? $"selected units: [{_selectedUnits.GetEntities(_buffer).Select(u => u.ID().ID).JoinToString()}]"
                : string.Empty;
    }
}