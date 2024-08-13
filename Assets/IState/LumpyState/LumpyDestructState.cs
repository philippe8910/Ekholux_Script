using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumpyDestructState : IState
{
    public LumpyActionComponent birdActionComponent;

    public void StateEnter(Object @object)
    {
        birdActionComponent = (LumpyActionComponent)@object;

        // 傷害計算 與 音效 與 特效

        // 鸟的销毁
        LumpyObjectManager.Instance.ReleaseBird(birdActionComponent);
    }

    public void StateExit()
    {
        
    }

    public void StateUpdate()
    {
        
    }
}
