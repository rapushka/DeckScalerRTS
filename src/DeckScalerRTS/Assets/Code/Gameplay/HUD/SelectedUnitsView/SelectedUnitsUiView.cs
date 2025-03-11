using System;
using Entitas;
using Entitas.Generic;
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

        private BaseUnitView _currentView;

        private AutoAttackState AutoAttackState
        {
            set
            {
                // ReSharper disable once SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
                _autoAttackTextMesh.text = value switch
                {
                    AutoAttackState.Attacking => "Auto-Attack Mode",
                    AutoAttackState.Ignore    => "Defence Mode",
                    AutoAttackState.Mixed     => Constants.LongDash,
                    _                         => throw new ArgumentOutOfRangeException(nameof(value), value, null),
                };
            }
        }

        private void Awake()
        {
            _autoAttackButton.onClick.AddListener(OnAutoAttackButtonClick);
            _singleView.ForceHideRequested += Hide;
            _multipleView.ForceHideRequested += Hide;
        }

        public void Hide()
        {
            Dispose();
            _currentView = null;
        }

        public void OnSelectionChanged(IGroup<Entity<GameScope>> units)
        {
            Dispose();
            _currentView = units.count switch
            {
                0 => null,
                1 => ShowForSingle(units.First()),
                _ => ShowForMultiple(units),
            };

            UpdateValue();
            _currentView?.Show();
        }

        public void UpdateValue()
        {
            _currentView?.UpdateValues();

            // view can Force Hide
            if (_currentView is null)
                return;

            _healthBar.HpData = _currentView.HpData;
            AutoAttackState = _currentView.AutoAttackState;
        }

        private void Dispose()
        {
            _singleView.Hide();
            _multipleView.Hide();

            _currentView?.Dispose();

            _healthBar.HpData = HpData.Empty();
            AutoAttackState = AutoAttackState.Mixed;
        }

        private void OnAutoAttackButtonClick()
        {
            _currentView?.OnAutoAttackButtonClick();
        }

        private BaseUnitView ShowForSingle(Entity<GameScope> unit)
        {
            _singleView.SetUnit(unit);
            return _singleView;
        }

        private BaseUnitView ShowForMultiple(IGroup<Entity<GameScope>> units)
        {
            _multipleView.SetUnits(units);
            return _multipleView;
        }
    }
}