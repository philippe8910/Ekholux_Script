using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDestructState : IState
{
    public BirdActionComponent birdActionComponent;

    public void StateEnter(Object @object)
    {
        birdActionComponent = (BirdActionComponent)@object;

        // 傷害計算 與 音效 與 特效

        // 鸟的销毁
        BirdObjectManager.Instance.ReleaseBird(birdActionComponent);
    }

    public void StateExit()
    {
        
    }

    public void StateUpdate()
    {
        
    }
}
