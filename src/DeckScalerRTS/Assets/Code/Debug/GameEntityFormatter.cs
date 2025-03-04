using System.Text;
using Entitas.Generic;

namespace DeckScaler
{
    public class GameEntityFormatter : EntityStringBuilderFormatter<GameScope>
    {
        protected override void BuildName(ref StringBuilder sb, in Entity<GameScope> e)
        {
            sb.Append(e.GetName());
            sb.Append(e.ToString<OnSide, Side>(prefix: " on side: "));

            sb.Append(e.Is<SelectedUnit>() ? "<- selected" : string.Empty);
        }
    }
}