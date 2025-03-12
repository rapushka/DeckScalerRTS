using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
    public class SelectedUnitsUiView : MonoBehaviour
    {
        [SerializeField] private SingleUnitUiView _singleView;
        [SerializeField] private MultipleUnitsUiView _multipleView;

        [Header("Health Bar")]
        [SerializeField] private ProgressBar _healthBar;

        [Header("Auto-Attack State Button")]
        [SerializeField] private Button _autoAttackButton;
        [SerializeField] private TMP_Text _autoAttackTextMesh;

        public SingleUnitUiView    SingleView   => _singleView;
        public MultipleUnitsUiView MultipleView => _multipleView;

        public ProgressBar HealthBar          => _healthBar;
        public TMP_Text    AutoAttackTextMesh => _autoAttackTextMesh;

        private void Awake()
        {
            _autoAttackButton.onClick.AddListener(OnAutoAttackButtonClick);
        }

        private void OnAutoAttackButtonClick()
        {
            CreateEntity.OneFrame()
                // .Add<FlipSelectedUnitAttackStateEvent>() TODO:
                ;
        }

        public void ShowSingle()
        {
            _multipleView.Hide();
            _singleView.Show();
        }

        public void ShowMultiple()
        {
            _singleView.Hide();
            _multipleView.Show();
        }

        public void Hide()
        {
            _singleView.Hide();
            _multipleView.Hide();
        }
    }
}