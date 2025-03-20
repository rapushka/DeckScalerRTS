using Entitas.Generic;
using TMPro;
using UnityEngine;

namespace DeckScaler
{
    public class PriceView : BaseListener<GameScope, Price>
    {
        [SerializeField] private TMP_Text _textMesh;
        [SerializeField] private string _format = "${0}";

        public override void OnValueChanged(Entity<GameScope> entity, Price component)
            => _textMesh.text = _format.Format(component.Value);
    }
}