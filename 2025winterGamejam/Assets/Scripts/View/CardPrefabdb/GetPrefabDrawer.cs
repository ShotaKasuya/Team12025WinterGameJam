#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace View.CardPrefabdb
{
    [CustomPropertyDrawer(typeof(GetPrefabAttribute))]
    public class GetPrefabDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.LabelField(new Rect(position.x, position.y , position.width,
                            EditorGUIUtility.singleLineHeight),property.name);
            GetPrefabAttribute getPrefabAttribute = (GetPrefabAttribute)attribute;
            System.Type getPrefabType = getPrefabAttribute.GetPrefabType;

            if (getPrefabType.IsEnum)
            {
                SerializedProperty listProperty = property.FindPropertyRelative("number");
                string[] enumNames = System.Enum.GetNames(getPrefabType);

                for (int i = 0; i < listProperty.arraySize; i++)
                {
                    SerializedProperty element = listProperty.GetArrayElementAtIndex(i);

                    EditorGUI.PropertyField(
                        new Rect(position.x, position.y + (i+1) * EditorGUIUtility.singleLineHeight, position.width,
                            EditorGUIUtility.singleLineHeight),
                        element,
                        new GUIContent(enumNames[i]),
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
            GetPrefabAttribute GetPrefabAttribute = (GetPrefabAttribute)attribute;
            System.Type getPrefabType = GetPrefabAttribute.GetPrefabType;

            if (getPrefabType.IsEnum)
            {
                int enumLength = System.Enum.GetNames(getPrefabType).Length + 2;
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