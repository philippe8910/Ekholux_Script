using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumpyDetectState : IState
{
    LumpyActionComponent birdActionComponent;
    public void StateEnter(Object @object)
    {
        birdActionComponent = (LumpyActionComponent)@object;
    }

    public void StateExit()
    {
        
    }

    public void StateUpdate()
    {
        if(Physics.CheckSphere(birdActionComponent.transform.position, birdActionComponent.birdParameterComponent.detectRange, birdActionComponent.playerLayer))
        {
            birdActionComponent.ChangeState(new LumpyChaseState());
        }
    }
}