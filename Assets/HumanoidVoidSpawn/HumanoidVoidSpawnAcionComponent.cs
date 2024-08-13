using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HumanoidVoidSpawnAcionComponent))]
public class HumanoidVoidSpawnAcionComponent : MonoBehaviour
{
    public HumanoidVoidParameterComponent parameterComponent;
    public IState currentState;

    private void Start()
    {
        parameterComponent = GetComponent<HumanoidVoidParameterComponent>();
        currentState = new HumanoidVoidSpawnDetectState();
    }

    public void ChangeState(IState newState)
    {

    }
}
