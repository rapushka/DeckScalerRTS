using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
    public class TimeManipulationUI : MonoBehaviour
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _speedupButton;

        private static ITimeService TimeService => ServiceLocator.Resolve<ITimeService>();

        public void Initialize()
        {
            _pauseButton.onClick.AddListener(TogglePause);
            _speedupButton.onClick.AddListener(ToggleSpeedup);
        }

        private void TogglePause() => TimeService.ToggleTimeStop();

        private void ToggleSpeedup() => TimeService.ToggleSpeedUp();
    }
}