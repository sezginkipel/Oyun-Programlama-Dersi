using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GPTInSpector))]
public class GPTInSpector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.HelpBox("This is a help box", MessageType.Info);
    }
    
    
    [MenuItem("Tools/Clear PlayerPrefs")]
    private static void NewMenuOption()
    {

        
    }
}
