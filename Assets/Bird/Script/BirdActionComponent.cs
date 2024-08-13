using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdActionComponent : MonoBehaviour
{
    public float detectRange;
    public Transform target;
    public LayerMask playerLayer;
    private IState currentState;
    //public AnimationCurve heightCurve;

    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
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
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}
