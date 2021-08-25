using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(UpgradeDataList),true)]
public class UpgradeProperyDrawer : PropertyDrawer
{
    private JUtil.PropertyDrawerUtility util;

    private GUIContent
            addButtonContent = new GUIContent("+", "add group"),
            removeButtonContent = new GUIContent("-", "remove group");

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float height = EditorGUIUtility.singleLineHeight;

        if (property.isExpanded)
            height += (5 + EditorGUIUtility.singleLineHeight) * (property.FindPropertyRelative("data").arraySize*3);

        return height;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        util = new JUtil.PropertyDrawerUtility(position);
        EditorGUI.BeginProperty(position, label, property);

        Rect dropdown = util.GetSingleLineRect();
        property.isExpanded = EditorGUI.Foldout(dropdown, property.isExpanded, property.displayName, true);
        if (!property.isExpanded)
        {
            EditorGUI.EndProperty();
            return;
        }


        if (property.FindPropertyRelative("data").arraySize <= 0)
        {
            EditorGUI.EndProperty();
            return;
        }

        JUtil.PropertyDrawerUtility.IndentLevel++;

        string[] names = property.FindPropertyRelative("data").GetArrayElementAtIndex(0).FindPropertyRelative("stat").enumDisplayNames;

        List<UpgradeData> data = ((PlayerStats)property.serializedObject.targetObject).upgradeData.data;

        for (int i = 0; i < property.FindPropertyRelative("data").arraySize;i++ )
        {
            SerializedProperty arrayElementProp = property.FindPropertyRelative("data").GetArrayElementAtIndex(i);
            util.NewLine();
            Rect rect = util.GetSingleLineRect();

            SerializedProperty temp = arrayElementProp.FindPropertyRelative("type");
            int type = temp.enumValueIndex;

            int index = arrayElementProp.FindPropertyRelative("stat").enumValueIndex;
            EditorGUI.LabelField(rect, names[index]);

            DrawButtons(property, i);

            JUtil.PropertyDrawerUtility.IndentLevel++;

            util.NewLine();
            rect = util.GetSingleLineRect();

            //int value = ((IntUpgrade)data[i]).data;

            EditorGUI.IntField(rect, "upgrade count", arrayElementProp.FindPropertyRelative("data").intValue);

            switch (type)
            {
                case (int)PlayerUpgrade.Type.INT:
                    {
                        util.NewLine();
                        rect = util.GetSingleLineRect();

                        int value = ((IntUpgrade)data[i]).value;

                        EditorGUI.IntField(rect, "current value",value);

                        //string name = childProp.stringValue;

                        //util.NewLine();
                        break;
                    }

                case (int)PlayerUpgrade.Type.FLOAT:
                    {
                        util.NewLine();
                        rect = util.GetSingleLineRect();

                        float value = ((FloatUpgrade)data[i]).value;

                        EditorGUI.FloatField(rect, "current value", value);

                        //util.NewLine();
                        break;
                    }
            }
            JUtil.PropertyDrawerUtility.IndentLevel--;
        }

        JUtil.PropertyDrawerUtility.IndentLevel--;

        EditorGUI.EndProperty();
    }

    private void DrawButtons(SerializedProperty prop, int index)
    {
        Rect dropdown = util.GetSingleLineRect();

        int indentlevelPrev = EditorGUI.indentLevel;

        EditorGUI.indentLevel = 0;

        dropdown.x = EditorGUIUtility.currentViewWidth - 103;
        dropdown.width = 98;

        DrawUpgradeButtons(dropdown, prop, index);

        EditorGUI.indentLevel = indentlevelPrev;
    }

    private void DrawUpgradeButtons(Rect rect, SerializedProperty prop, int index)
    {
        rect.width /= 2;

        if (GUI.Button(rect, addButtonContent))
        {
            (prop.serializedObject.targetObject as PlayerStats).UpgradeStat(index, 1);
        }

        rect.x += rect.width;

        if (GUI.Button(rect, removeButtonContent))
        {
            (prop.serializedObject.targetObject as PlayerStats).UpgradeStat(index, -1);
        }
    }
}
