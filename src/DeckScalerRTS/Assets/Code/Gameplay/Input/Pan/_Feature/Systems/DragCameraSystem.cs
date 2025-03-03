using DeckScaler.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    // public sealed class DragCameraSystem : IExecuteSystem // TODO: ERMOVE ME
    // {
    //     private readonly IGroup<Entity<InputScope>> _inputs
    //         = GroupBuilder<InputScope>
    //             .With<PlayerInput>()
    //             .And<DraggingCamera>()
    //             .And<MouseDelta>()
    //             .Build();
    //
    //     private static Camera MainCamera => ServiceLocator.Resolve<ICameraService>().MainCamera;
    //
    //     public void Execute()
    //     {
    //         foreach (var input in _inputs)
    //         {
    //             var mouseMovement = input.Get<MouseDelta>().Value;
    //             mouseMovement.x *= -1;
    //             mouseMovement.y *= -1;
    //             MainCamera.transform.Translate(mouseMovement);
    //             // MainCamera.transform.localPosition = mouseMovement.Extend(MainCamera.transform.localPosition.z);
    //         }
    //     }
    // }
}