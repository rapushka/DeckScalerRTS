using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class Clickable : FlagComponent, IInScope<GameScope> { }

    public sealed class Clicked : FlagComponent, IInScope<GameScope>, ICleanup<RemoveComponent> { }

    public sealed class Collider : ValueComponent<Collider2D>, IInScope<GameScope> { }
}