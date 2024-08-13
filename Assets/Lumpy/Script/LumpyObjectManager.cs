using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class LumpyObjectManager : SingletonMonoBehaviour<LumpyObjectManager>
{
    public LumpyActionComponent birdPrefab;
    public ObjectPool<LumpyActionComponent> pool;

    void Start()
    {
        pool = new ObjectPool<LumpyActionComponent>(() => { return Instantiate(birdPrefab); },
        bird => { bird.gameObject.SetActive(true); },
        bird => { bird.gameObject.SetActive(false);},
        bird => Destroy(bird.gameObject), false, 10);
    }

    [ContextMenu("GetBirdTest")]
    public void GetBirdTest()
    {
        GetBird(Vector3.zero);
    }

    public void GetBird(Vector3 position)
    {
        var bird = pool.Get();
        bird.transform.position = position;
    }

    public void ReleaseBird(LumpyActionComponent bird)
    {
        pool.Release(bird);
    }

    public void Clear()
    {
        pool.Clear();
    }
}
