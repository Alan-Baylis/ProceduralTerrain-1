using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CustomTerrain))]
public class CustomTerrainEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CustomTerrain tg = target as CustomTerrain;

        if (GUILayout.Button("Regenerate"))
        {
            if (tg != null)
            {
                tg.Regenerate();
            }
        }
        if (GUILayout.Button("Save"))
        {
            if (tg != null)
            {
                tg.SaveMesh();
            }
        }
        if (GUILayout.Button("Load"))
        {
            if (tg != null)
            {
                tg.LoadMesh();
            }
        }
    }

}
