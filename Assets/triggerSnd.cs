using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class triggerSnd : MonoBehaviour
{
    Rigidbody jetpackRb;
    AudioSource myAS;

    public bool isTrigger;
    public bool isDebug;

    [SerializeField] private UnityEvent onTriggerOnceEvents;
    [SerializeField] private UnityEvent onTriggerEndEvents;

    void Start()
    {
        try 
        {
            jetpackRb = GameObject.Find("jetpackRoot").GetComponent<Rigidbody>();
        }
        catch (NullReferenceException e)
        {
            Debug.LogWarning($"Can not find jetpackRoot, create new jatpackRigidBody.");            
        }

        myAS = GetComponent<AudioSource>();

        onTriggerOnceEvents.AddListener(MusicPlay);

        onTriggerEndEvents.AddListener(SaveTriggerState);
        onTriggerEndEvents.AddListener(() => ChangeLightMaterial(Color.blue));

        if(isDebug)
            LoadTriggerState();

        if(isTrigger)
        {
            onTriggerEndEvents.Invoke();
        }
    }

    private void MusicPlay()
    {
        myAS.pitch = UnityEngine.Random.Range(0.7f, 1.4f);
        float lerpRatio = (jetpackRb != null) ? jetpackRb.velocity.magnitude / 30f : 1f;
        myAS.volume = Mathf.Lerp(0.3f, 1f, lerpRatio);
        myAS.Play();
    }

    private void ChangeLightMaterial(Color targetColor)
    {
        var meshRenderer = GetComponent<MeshRenderer>();
        var material = meshRenderer.material;

        material.SetColor("_Color", targetColor);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");

        if (other.gameObject.CompareTag("Player"))
        {
            isTrigger = true;

            onTriggerOnceEvents?.Invoke();
            onTriggerEndEvents?.Invoke();
            Debug.Log("Player is in trigger");
        }
    }

    private void SaveTriggerState()
    {
        var getID = gameObject.GetInstanceID();
        PlayerPrefs.SetInt(getID.ToString() , isTrigger ? 1 : 0);

        Debug.Log($"Save trigger state: {isTrigger}");
    }

    private void LoadTriggerState()
    {
        var getID = gameObject.GetInstanceID();
        isTrigger = PlayerPrefs.GetInt(getID.ToString()) == 1;

        Debug.Log($"Load trigger state: {isTrigger}");
    }
}
