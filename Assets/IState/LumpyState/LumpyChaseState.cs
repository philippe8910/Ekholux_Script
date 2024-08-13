using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumpyChaseState : IState
{   
    public Transform target;  // 目标点
    public Vector3 offset;  // 偏移量
    

    private LumpyActionComponent birdActionComponent;
    private LumpyParameterComponent birdParameterComponent;

    public void StateEnter(Object @object)
    {
        birdActionComponent = (LumpyActionComponent)@object;
        birdParameterComponent = birdActionComponent.birdParameterComponent;

        offset = new Vector3(Random.Range(-birdParameterComponent.detectRange, birdParameterComponent.detectRange), Random.Range(0, birdParameterComponent.detectRange), Random.Range(-birdParameterComponent.detectRange, birdParameterComponent.detectRange));
        target = birdActionComponent.target;
    }

    public void StateExit()
    {
        
    }

    public void StateUpdate()
    {
        if(Vector3.Distance(birdActionComponent.transform.position, target.position) > birdParameterComponent.nearDistance)
        {
            birdActionComponent.transform.position = Vector3.MoveTowards(birdActionComponent.transform.position, target.position + offset, birdParameterComponent.maxSpeed * Time.deltaTime);
        }
        else
        {
            birdActionComponent.transform.RotateAround(target.position, Vector3.up, 30 * Time.deltaTime);
            birdActionComponent.transform.position = Vector3.MoveTowards(birdActionComponent.transform.position, target.position, .3f * Time.deltaTime);
        }
    }    
}
