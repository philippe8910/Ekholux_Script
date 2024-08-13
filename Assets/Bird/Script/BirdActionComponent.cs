using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BirdParameterComponent))]
public class BirdActionComponent : MonoBehaviour
{
    public Transform target;
    public LayerMask playerLayer;
    private IState currentState;
    public BirdParameterComponent birdParameterComponent;

    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        birdParameterComponent = GetComponent<BirdParameterComponent>();
    }

    private void OnEnable()
    {
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
