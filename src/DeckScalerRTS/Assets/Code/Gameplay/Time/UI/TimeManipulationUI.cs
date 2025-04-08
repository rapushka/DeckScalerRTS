using UnityEngine;

namespace DeckScaler
{
    public class TimeManipulationUI : MonoBehaviour
    {
        [SerializeField] private ToggleButton _pauseToggle;
        [SerializeField] private ToggleButton _speedupToggle;

        private static ITimeService TimeService => ServiceLocator.Resolve<ITimeService>();

        public void Initialize()
        {
            _pauseToggle.Clicked += TogglePause;
            _speedupToggle.Clicked += ToggleSpeedup;
        }

        private void TogglePause() => TimeService.ToggleTimeStop();

        private void ToggleSpeedup() => TimeService.ToggleSpeedUp();
    }
}