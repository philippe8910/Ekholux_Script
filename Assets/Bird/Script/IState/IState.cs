using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState 
{
    public void StateEnter(Object @object);
    public void StateExit();
    public void StateUpdate();
}
