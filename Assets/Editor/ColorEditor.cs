using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class ColorEditor : EditorWindow
{
    private Color matColor = Color.white;
    
    [MenuItem("Tools/Color Editor _c")]
    public static void ChangeColor()
    {
        EditorWindow.GetWindow<ColorEditor>();
    }

    private void OnGUI()
    {
        matColor = EditorGUILayout.ColorField("New Color", matColor);

        if (GUILayout.Button("Change!"))
            ChangeColors();
    }
    
    private void ChangeColors()
    {
        var objects = FindObjectsOfType<Renderer>() as Renderer[];
        foreach (var o in objects)
        {
            o.sharedMaterial.color = matColor;
        }
    }
}
