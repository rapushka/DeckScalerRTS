using Entitas.Generic;

namespace DeckScaler
{
    public class GameplayFeatureRunner : FeatureAdapterBase<GameplayFeature>
    {
        protected override void Dispose()
        {
            foreach (var entity in Contexts.Instance.Get<GameScope>().GetEntities())
                entity.Is<Destroy>(true);

            foreach (var entity in Contexts.Instance.Get<InputScope>().GetEntities())
                entity.Destroy();
        }
    }
}