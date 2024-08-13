using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidVoidSpawnDetectState : IState
{
    private HumanoidVoidSpawnAcionComponent acionComponent;

    public void StateEnter(Object @object)
    {
        acionComponent = (HumanoidVoidSpawnAcionComponent)@object;
    }

    public void StateExit()
    {
        
    }

    public void StateUpdate()
    {
        
    }
}
