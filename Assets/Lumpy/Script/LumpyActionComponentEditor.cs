using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LumpyActionComponent))]
public class BirdActionComponentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        LumpyActionComponent birdActionComponent = (LumpyActionComponent)target;

        if (GUILayout.Button("Change State: Detect"))
        {
            birdActionComponent.ChangeState(new LumpyDetectState());
        }

        if (GUILayout.Button("Change State: Chase"))
        {
            birdActionComponent.ChangeState(new LumpyChaseState());
        }

        if (GUILayout.Button("Change State: Destruct"))
        {
            birdActionComponent.ChangeState(new LumpyDestructState());
        }
    }
}
