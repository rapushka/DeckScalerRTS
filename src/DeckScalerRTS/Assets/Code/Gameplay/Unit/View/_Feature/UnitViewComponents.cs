using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class SpriteColor : ValueComponent<Color>, IInScope<GameScope>, IEvent<Self> { }
}