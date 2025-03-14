using System.Collections.Generic;
using System.Linq;
using DeckScaler;
using SmartIdTable;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(UnitIDAttribute))]
public class UnitIDDrawer : PropertyDrawer
{
    public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType != SerializedPropertyType.String)
        {
            EditorGUI.LabelField(rect, label.text, "Use UnitIDAttribute with string fields only.");
            return;
        }

        var unitIDs = GetUnitIDs();

        var displayNames = unitIDs.Values.ToList();
        var currentValue = property.stringValue;

        var selectedIndex = unitIDs.Keys.ToList().IndexOf(currentValue);
        if (selectedIndex < 0)
            selectedIndex = 0;

        selectedIndex = EditorGUI.Popup(rect, label.text, selectedIndex, displayNames.ToArray());

        if (selectedIndex >= 0 && selectedIndex < unitIDs.Count)
            property.stringValue = unitIDs.Keys.ToList()[selectedIndex];
    }

    private static Dictionary<string, string> GetUnitIDs()
    {
        var dictionary = $"{Constants.TableID.Units}Unknown".AsSingleItemArray()
            .Concat(IdTable.Get().Ids)
            .Where(id => id.Contains(Constants.TableID.Units))
            .ToDictionary(id => id, id => id.Remove(Constants.TableID.Units));
        return dictionary;
    }
}