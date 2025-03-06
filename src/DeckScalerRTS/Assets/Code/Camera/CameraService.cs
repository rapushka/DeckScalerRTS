using UnityEngine;

namespace DeckScaler
{
    public interface ICameraService : IService
    {
        Camera MainCamera { get; }
        Camera UiCamera   { get; }
    }

    public class CameraService : ICameraService
    {
        public CameraService(Camera mainCamera, Camera uiCamera)
        {
            MainCamera = mainCamera;
            UiCamera = uiCamera;
        }

        public Camera MainCamera { get; }
        public Camera UiCamera   { get; }
    }
}