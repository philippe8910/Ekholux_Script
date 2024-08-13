using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BirdParameterComponent))]
public class BirdActionComponent : MonoBehaviour
{
    public Transform target;
    public LayerMask playerLayer;
    public BirdParameterComponent birdParameterComponent;


    private IState currentState;

    private void OnEnable()
    {
        target = GameObject.FindWithTag("Player").transform;
        birdParameterComponent = GetComponent<BirdParameterComponent>();

        ChangeState(new BirdDetectState());
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
