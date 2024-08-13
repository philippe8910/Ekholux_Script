using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class BirdObjectManager : SingletonMonoBehaviour<BirdObjectManager>
{
    public BirdActionComponent birdPrefab;
    public ObjectPool<BirdActionComponent> pool;

    void Start()
    {
        pool = new ObjectPool<BirdActionComponent>(() => { return Instantiate(birdPrefab); },
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

    public void ReleaseBird(BirdActionComponent bird)
    {
        pool.Release(bird);
    }

    public void Clear()
    {
        pool.Clear();
    }
}
