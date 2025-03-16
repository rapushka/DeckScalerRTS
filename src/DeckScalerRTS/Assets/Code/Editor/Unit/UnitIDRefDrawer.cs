using UnityEditor;
using UnityEngine;

namespace DeckScaler
{
    [CustomPropertyDrawer(typeof(UnitIDRef))]
    public class UnitIDRefDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
        {
            var valueProperty = property.FindPropertyRelative(nameof(UnitIDRef.Value));
            EditorGUI.PropertyField(rect, valueProperty, label, true);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var valueProperty = property.FindPropertyRelative(nameof(UnitIDRef.Value));
            return EditorGUI.GetPropertyHeight(valueProperty, label, true);
        }
    }
}