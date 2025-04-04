using Entitas.Generic;

namespace DeckScaler
{
    public interface IInfluenceFactory : IService
    {
        Entity<GameScope> Create(Entity<GameScope> owner, StatID stat, Modifier modifier);
    }

    public class InfluenceFactory : IInfluenceFactory
    {
        public Entity<GameScope> Create(Entity<GameScope> owner, StatID stat, Modifier modifier)
        {
            var ownerID = owner.ID();

            return CreateEntity.Empty()
                    .Add<DebugName, string>("influence")
                    .Is<Influence>(true)
                    .Add<ChildOf, EntityID>(ownerID)
                    .Add<InfluenceModifier, Modifier>(modifier)
                    .Add<TargetStat, StatID>(stat)
                ;
        }
    }
}