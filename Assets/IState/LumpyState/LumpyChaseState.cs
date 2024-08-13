using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumpyChaseState : IState
{   
    public Transform target;  // 目标点
    

    private LumpyActionComponent birdActionComponent;
    private LumpyParameterComponent birdParameterComponent;

    public void StateEnter(Object @object)
    {
        birdActionComponent = (LumpyActionComponent)@object;
        birdParameterComponent = birdActionComponent.birdParameterComponent;

        target = birdActionComponent.target;
        birdParameterComponent.elapsedTime = 0;
    }

    public void StateExit()
    {
        
    }

    public void StateUpdate()
    {
        if (birdParameterComponent.elapsedTime < birdParameterComponent.moveDuration)
        {
            birdParameterComponent.elapsedTime += Time.deltaTime;

            
            float t = birdParameterComponent.elapsedTime / birdParameterComponent.moveDuration;

            
            float baseHeight = Mathf.Lerp(birdParameterComponent.startHeight, birdParameterComponent.endHeight, t);
            float currentRadius = Mathf.Lerp(birdParameterComponent.startRadius, birdParameterComponent.endRadius, t);

            
            float oscillation = Mathf.Sin(birdParameterComponent.elapsedTime * birdParameterComponent.oscillationFrequency) * birdParameterComponent.oscillationAmplitude;
            float currentHeight = baseHeight + oscillation;

            
            float angle = birdParameterComponent.rotationSpeed * birdParameterComponent.elapsedTime;
            float radian = angle * Mathf.Deg2Rad;

            
            Vector3 offset = new Vector3(Mathf.Cos(radian) * currentRadius, currentHeight, Mathf.Sin(radian) * currentRadius);
            birdActionComponent.transform.position = Vector3.Lerp(birdActionComponent.transform.position, target.position + offset, Time.deltaTime);

            
            birdActionComponent.transform.LookAt(target);
        }
        else
        {
            birdActionComponent.ChangeState(new LumpyDestructState());
        }
    }    
}
