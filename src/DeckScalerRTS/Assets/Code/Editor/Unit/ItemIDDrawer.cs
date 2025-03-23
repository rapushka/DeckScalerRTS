using System.Collections.Generic;
using System.Linq;
using DeckScaler;
using SmartIdTable;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ItemIDAttribute))]
public class ItemIDDrawer : PropertyDrawer
{
    public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType != SerializedPropertyType.String)
        {
            EditorGUI.LabelField(rect, label.text, "Use ItemIDAttribute with string fields only.");
            return;
        }

        var itemIDs = GetItemIDs();

        var displayNames = itemIDs.Values.ToList();
        var currentValue = property.stringValue;

        var selectedIndex = itemIDs.Keys.ToList().IndexOf(currentValue);
        if (selectedIndex < 0)
            selectedIndex = 0;

        selectedIndex = EditorGUI.Popup(rect, label.text, selectedIndex, displayNames.ToArray());

        if (selectedIndex >= 0 && selectedIndex < itemIDs.Count)
            property.stringValue = itemIDs.Keys.ToList()[selectedIndex];
    }

    private static Dictionary<string, string> GetItemIDs()
    {
        var dictionary = $"{Constants.TableID.Items}Unknown".AsSingleItemArray()
            .Concat(IdTable.Get().Ids)
            .Where(id => id.Contains(Constants.TableID.Items))
            .ToDictionary(id => id, id => id.Remove(Constants.TableID.Items));
        return dictionary;
    }
}