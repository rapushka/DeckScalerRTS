using Entitas.Generic;
using TMPro;
using UnityEngine;

namespace DeckScaler
{
    public class UseCommentView : BaseListener<UiScope, UseComment>
    {
        [SerializeField] private TMP_Text _textMesh;

        [SerializeField] private Color _validColor = Color.white;
        [SerializeField] private Color _invalidColor = Color.red;

        public override void OnValueChanged(Entity<UiScope> entity, UseComment component)
        {
            _textMesh.text = component.Value;

            _textMesh.color = entity.GetOrDefault<ValidUsage, bool>(true)
                ? _validColor
                : _invalidColor;
        }
    }
}