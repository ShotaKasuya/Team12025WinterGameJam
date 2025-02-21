#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Utility.Structure.InGame;

[CustomPropertyDrawer(typeof(EnumListAttribute))]
public class EnumListDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EnumListAttribute enumListAttribute = (EnumListAttribute)attribute;
        System.Type enumType = enumListAttribute.EnumType;

        if (enumType.IsEnum)
        {
            SerializedProperty listProperty = property.FindPropertyRelative("effectName");
            SerializedProperty listProperty2 = property.FindPropertyRelative("description");
            string[] enumNames = System.Enum.GetNames(enumType);

            for (int i = 0; i < listProperty.arraySize; i++)
            {
                SerializedProperty element = listProperty.GetArrayElementAtIndex(i);
                SerializedProperty element2 = listProperty2.GetArrayElementAtIndex(i);

                EditorGUI.PropertyField(
                    new Rect(position.x, position.y + (i * 3) * EditorGUIUtility.singleLineHeight, position.width,
                        EditorGUIUtility.singleLineHeight),
                    element,
                    new GUIContent(enumNames[i] + "Effect Name"),
                    true);

                EditorGUI.PropertyField(
                    new Rect(position.x, position.y + (i * 3 + 1) * EditorGUIUtility.singleLineHeight, position.width,
                        EditorGUIUtility.singleLineHeight * 2),
                    element2,
                    new GUIContent(enumNames[i] + "Description"),
                    true);
            }
        }
        else
        {
            EditorGUI.LabelField(position, label.text, "Use EnumList with Enum type.");
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        EnumListAttribute enumListAttribute = (EnumListAttribute)attribute;
        System.Type enumType = enumListAttribute.EnumType;

        if (enumType.IsEnum)
        {
            int enumLength = System.Enum.GetNames(enumType).Length * 2;
            return enumLength * EditorGUIUtility.singleLineHeight;
        }
        else
        {
            return EditorGUIUtility.singleLineHeight;
        }
    }
}
#endif