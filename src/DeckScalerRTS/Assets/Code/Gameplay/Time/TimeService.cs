using UnityEngine;

namespace DeckScaler
{
    public interface ITimeService : IService
    {
        float GameplayDelta { get; }

        float RealDelta { get; }

        void ToggleTimeStop();

        void ToggleSpeedUp();
    }

    public class TimeService : ITimeService
    {
        private bool _isTimeStopEnabled;
        private float? _timeScale;

        public float GameplayDelta => _isTimeStopEnabled
            ? 0
            : Time.deltaTime * TimeScale;

        public float RealDelta => Time.deltaTime;

        private float TimeScale => _timeScale ?? 1f;

        public void ToggleTimeStop()
            => _isTimeStopEnabled = !_isTimeStopEnabled;

        public void ToggleSpeedUp()
            => _timeScale = _timeScale.HasValue ? null : 2f;
    }
}