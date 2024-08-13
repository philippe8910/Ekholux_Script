using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LumpyParameterComponent))]
public class LumpyActionComponent : MonoBehaviour
{
    public Transform target;
    public LayerMask playerLayer;
    public LumpyParameterComponent birdParameterComponent;


    private IState currentState;

    private void OnEnable()
    {
        target = GameObject.FindWithTag("Player").transform;
        birdParameterComponent = GetComponent<LumpyParameterComponent>();

        ChangeState(new LumpyDetectState());
    }

    private void Update()
    {
        currentState.StateUpdate();
    }

    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.StateExit();
        }
        currentState = newState;
        currentState.StateEnter(this);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, birdParameterComponent.detectRange);
    }
}
