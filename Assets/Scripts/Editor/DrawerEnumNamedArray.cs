using UnityEngine;
using UnityEditor;
using System;

[CustomPropertyDrawer(typeof(EnumNamedArrayAttribute))]
public class DrawerEnumNamedArray : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EnumNamedArrayAttribute enumNames = attribute as EnumNamedArrayAttribute;
        int index = System.Convert.ToInt32(property.propertyPath.Substring(property.propertyPath.LastIndexOf("[")).Replace("[", "").Replace("]", ""));

        if (index < enumNames.names.Length)
            label.text = enumNames.names[index];

        EditorGUI.PropertyField(position, property, label, true);
    }
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) { return EditorGUI.GetPropertyHeight(property, label, true); }
}