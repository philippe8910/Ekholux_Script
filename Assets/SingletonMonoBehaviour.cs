using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = (T)(object)this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
