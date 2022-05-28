using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;
public class ReadOnlyAttribute : PropertyAttribute
{
 
}
[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property,
        GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }
 
    public override void OnGUI(Rect position,
        SerializedProperty property,
        GUIContent label)
    {
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label, true);
        GUI.enabled = true;
    }
}
public class ColorManager : MonoBehaviour
{
    private static int colorEnumLength = Enum.GetNames(typeof(ProjectColors)).Length;
    [SerializeField] public List<Color> MyColorsList;
    [ReadOnly] public List<string> MyColorsNames = new(colorEnumLength);

    private ProjectColors colorsEnum;
    public static ColorManager Instance { get; private set; }
    void Start()
    {
        if (Instance != null && Instance != this) 
        { Destroy(this); } 
        else 
        { Instance = this; }
        
        
        for (int i=0; i< colorEnumLength; i++)
        {
            MyColorsNames[i] = ((ProjectColors)i).ToString();
        }
    }
    
}

[Serializable]
public  enum ProjectColors
{
    primary,
    secondary,
    accent,
    black,
    grey,
    lightgrey, 
    white
}
