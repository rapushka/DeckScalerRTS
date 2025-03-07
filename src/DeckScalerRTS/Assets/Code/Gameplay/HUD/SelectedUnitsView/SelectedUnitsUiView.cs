using System;
using Entitas;
using Entitas.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
    public enum AutoAttackState
    {
        Unknown = 0,
        Attacking = 1,
        Ignore = 2,
        Mixed = 3,
    }

    public class SelectedUnitsUiView : MonoBehaviour
    {
        [SerializeField] private SingleUnitUiView _singleView;
        [SerializeField] private MultipleUnitsUiView _multipleView;

        [Header("Health Bar")]
        [SerializeField] private Image _healthBar;
        [SerializeField] private TMP_Text _healthTextMesh;

        [Header("Auto-Attack State Button")]
        [SerializeField] private Button _autoAttackButton;
        [SerializeField] private TMP_Text _autoAttackTextMesh;

        private BaseUnitView _currentView;

        private float HealthBarFill { set => _healthBar.fillAmount = value; }

        private AutoAttackState AutoAttackState
        {
            set
            {
                // ReSharper disable once SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
                _autoAttackTextMesh.text = value switch
                {
                    AutoAttackState.Attacking => "Auto-Attack Mode",
                    AutoAttackState.Ignore    => "Defence Mode",
                    AutoAttackState.Mixed     => "———",
                    _                         => throw new ArgumentOutOfRangeException(nameof(value), value, null),
                };
            }
        }

        private void Awake()
        {
            _autoAttackButton.onClick.AddListener(OnAutoAttackButtonClick);
        }

        public void UpdateUnits(IGroup<Entity<GameScope>> units)
        {
            _singleView.Hide();
            _multipleView.Hide();

            _currentView = units.count switch
            {
                0 => HideCurrentView(),
                1 => ShowForSingle(units.First()),
                _ => ShowForMultiple(units),
            };

            if (_currentView is null)
                return;

            _currentView.Show();
            var health = _currentView.Health;
            var maxHealth = _currentView.MaxHealth;
            HealthBarFill = (float)maxHealth / health;
            AutoAttackState = _currentView.AutoAttackState;
        }

        private void OnAutoAttackButtonClick()
        {
            _currentView?.OnAutoAttackButtonClick();
        }

        private BaseUnitView HideCurrentView()
        {
            HealthBarFill = 0f;
            _healthTextMesh.text = string.Empty;

            return null;
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