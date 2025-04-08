using UnityEngine;

namespace DeckScaler
{
    public interface ITimeService : IService
    {
        bool IsTimeStopped { get; }

        float GameplayDelta { get; }

        float RealDelta { get; }

        void ToggleTimeStop();

        void ToggleSpeedUp();
    }

    public class TimeService : ITimeService
    {
        private float? _timeScale;

        public float GameplayDelta => IsTimeStopped
            ? 0
            : Time.deltaTime * TimeScale;

        public float RealDelta => Time.deltaTime;

        public bool IsTimeStopped { get; private set; }

        private float TimeScale => _timeScale ?? 1f;

        public void ToggleTimeStop()
            => IsTimeStopped = !IsTimeStopped;

        public void ToggleSpeedUp()
            => _timeScale = _timeScale.HasValue ? null : 2f;
    }
}