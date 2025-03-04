#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Utility.Structure.InGame
{
    [CustomPropertyDrawer(typeof(EnumListAttribute))]
    public class EnumListDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EnumListAttribute enumListAttribute = (EnumListAttribute)attribute;
            System.Type enumType = enumListAttribute.EnumType;

            if (enumType.IsEnum)
            {
                string[] enumNames = System.Enum.GetNames(enumType);
                for (int i = 0; i < property.arraySize; i++)
                {
                    var listElement = property.GetArrayElementAtIndex(i);
                    var enumName = enumNames[i];

                    EditorGUI.PropertyField(
                        new Rect(position.x, position.y + i * EditorGUIUtility.singleLineHeight, position.width,
                            EditorGUIUtility.singleLineHeight),
                        listElement,
                        new GUIContent(enumName),
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
                int enumLength = System.Enum.GetNames(enumType).Length;
                return enumLength * EditorGUIUtility.singleLineHeight;
            }
            else
            {
                return EditorGUIUtility.singleLineHeight;
            }
        }
    }
}
#endif