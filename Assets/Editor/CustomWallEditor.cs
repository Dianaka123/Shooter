using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WallRendering))]
public class CustomWallEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var wallRendering = target as WallRendering;
        if (GUILayout.Button("Reset"))
        {
            if (!(wallRendering is null))
                wallRendering.GetComponent<Renderer>().sharedMaterial.color = wallRendering.startColor;
        }
    }
}

