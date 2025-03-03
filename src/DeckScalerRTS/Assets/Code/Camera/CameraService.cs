using UnityEngine;

namespace DeckScaler
{
    public interface ICameraService : IService
    {
        Camera MainCamera { get; }
    }

    public class CameraService : ICameraService
    {
        public CameraService(Camera mainCamera)
        {
            MainCamera = mainCamera;
        }

        public Camera MainCamera { get; }
    }
}