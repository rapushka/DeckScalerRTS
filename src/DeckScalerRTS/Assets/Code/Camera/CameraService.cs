using UnityEngine;

namespace DeckScaler
{
    public interface ICameraService : IService
    {
        Camera MainCamera { get; }
        Camera UiCamera   { get; }

        Vector2 WorldToScreen(Vector2 worldPosition);
        Vector2 ScreenToWorld(Vector2 screenPosition);
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

        public Vector2 WorldToScreen(Vector2 worldPosition) => MainCamera.WorldToScreenPoint(worldPosition);

        public Vector2 ScreenToWorld(Vector2 screenPosition) => MainCamera.ScreenToWorldPoint(screenPosition);
    }
}