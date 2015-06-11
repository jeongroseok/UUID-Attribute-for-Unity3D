using UnityEngine;
using UnityEditor;


[CustomPropertyDrawer(typeof(UUIDAttribute))]
public class UUIDDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // check property type
        if (property.propertyType != SerializedPropertyType.String)
        {
            EditorGUI.LabelField(position, label.text, "Only string support.");
            return;
        }

        position.width -= (40 + 5);
        property.stringValue = EditorGUI.TextField(position, label.text, property.stringValue);

        // new uuid
        position.x += position.width + 5;
        position.width = 40;
        if (GUI.Button(position, "New") || string.IsNullOrEmpty(property.stringValue))
            property.stringValue = System.Guid.NewGuid().ToString();
    }
}
