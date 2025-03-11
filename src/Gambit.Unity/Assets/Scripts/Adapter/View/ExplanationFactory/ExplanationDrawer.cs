using UnityEditor;
using UnityEngine;

namespace Gambit.Unity.Adapter.View.ExplanationFactory
{
    [CustomPropertyDrawer(typeof(ExplanationAttribute))]
    public class ExplanationDrawer: PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.LabelField(new Rect(position.x, position.y , position.width,
                EditorGUIUtility.singleLineHeight),property.name);
            ExplanationAttribute explanationAttribute = (ExplanationAttribute)attribute;
            System.Type ExplanationType = explanationAttribute.ExplanationType;

            if (ExplanationType.IsEnum)
            {
                SerializedProperty listProperty = property.FindPropertyRelative("number");
                string[] enumNames = System.Enum.GetNames(ExplanationType);

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
            ExplanationAttribute explanationAttribute = (ExplanationAttribute)attribute;
            System.Type ExplanationType = explanationAttribute.ExplanationType;

            if (ExplanationType.IsEnum)
            {
                int enumLength = System.Enum.GetNames(ExplanationType).Length + 2;
                return enumLength * EditorGUIUtility.singleLineHeight;
            }
            else
            {
                return EditorGUIUtility.singleLineHeight;
            }
        }
    }
}