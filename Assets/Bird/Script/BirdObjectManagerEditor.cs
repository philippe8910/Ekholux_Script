using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BirdObjectManager))]
public class BirdObjectManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        BirdObjectManager birdObjectManager = (BirdObjectManager)target;

        if (GUILayout.Button("Create Bird From Vector Zero"))
        {
            birdObjectManager.GetBird(Vector3.zero);
        }

        if(GUILayout.Button("Release All Bird"))
        {
            
        }

        if (GUILayout.Button("Clear Pool"))
        {
            birdObjectManager.Clear();
        }
    }
}
