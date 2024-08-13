using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BirdActionComponent))]
public class BirdActionComponentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        BirdActionComponent birdActionComponent = (BirdActionComponent)target;

        if (GUILayout.Button("Change State: Detect"))
        {
            birdActionComponent.ChangeState(new BirdDetectState());
        }

        if (GUILayout.Button("Change State: Chase"))
        {
            birdActionComponent.ChangeState(new BirdChaseState());
        }

        if (GUILayout.Button("Change State: Destruct"))
        {
            birdActionComponent.ChangeState(new BirdDestructState());
        }
    }
}
