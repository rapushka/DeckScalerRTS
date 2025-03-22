using System.Linq;
using System.Text;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class GameEntityFormatter : EntityStringBuilderFormatter<GameScope>
    {
        protected override void BuildName(ref StringBuilder stringBuilder, in Entity<GameScope> entity)
        {
            var buffer = new[]
            {
                entity.GetOrDefault<ID>()?.Value.ID.ToString() ?? "_",
                $"{entity.GetName()} |",

                // unit
                entity.ToString<OnSide, Side>(prefix: "on side: "),
                entity.Is<SelectedUnit>() ? "<- selected" : string.Empty,
                ToStringID<OnTent>(entity, prefix: "on tent: "),
                ToStringHealth(entity),

                // ability
                ToStringID<AbilityOwner>(entity, prefix: "ability of: "),
                entity.ToString<CooldownTimer, Timer>(prefix: "cd: "),

                // tent
                entity.ToString<Tent>(),

                $"{entity.ToString<WorldPosition, Vector2>(),20}",
            };

            stringBuilder.AppendJoin(separator: "  ", buffer.Where(s => !s.IsEmpty()));
        }

        private static string ToStringHealth(in Entity<GameScope> entity)
        {
            if (entity.TryGet<Health, float>(out var health)
                && entity.TryGet<MaxHealth, float>(out var maxHealth))
                return $"HP: {health:### ###}/{maxHealth:### ###}";

            return string.Empty;
        }

        private static string ToStringID<TComponent>(in Entity<GameScope> entity, string prefix = "", string postfix = "", string defaultValue = "")
            where TComponent : ValueComponent<EntityID>, IInScope<GameScope>, new()
            => entity.TryGet<TComponent, EntityID>(out var unitID)
                ? $"{prefix}{unitID.GetEntity().ID().ID}{postfix}"
                : defaultValue;
    }
}