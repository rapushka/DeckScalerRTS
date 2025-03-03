using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class DragCameraOrigin : ValueComponent<Vector2>, IInScope<InputScope> { }
}