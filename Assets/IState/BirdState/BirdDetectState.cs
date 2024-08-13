using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDetectState : IState
{
    BirdActionComponent birdActionComponent;
    public void StateEnter(Object @object)
    {
        birdActionComponent = (BirdActionComponent)@object;
    }

    public void StateExit()
    {
        
    }

    public void StateUpdate()
    {
        if(Physics.CheckSphere(birdActionComponent.transform.position, birdActionComponent.birdParameterComponent.detectRange, birdActionComponent.playerLayer))
        {
            birdActionComponent.ChangeState(new BirdChaseState());
        }
    }
}