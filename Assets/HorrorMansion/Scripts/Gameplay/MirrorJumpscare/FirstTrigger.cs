using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTrigger : MonoBehaviour
{
    [SerializeField] private GameObject creepyReflection;
    [SerializeField] private GameObject secondTrigger;
    [SerializeField] private GameObject audioManagerHolder;

    private AudioManager audioManager;

    private bool firsTime = true;

    private void Start()
    {
        audioManager = audioManagerHolder.GetComponent<AudioManager>();
    }

    public void OnTriggerEnter(Collider coll)
    {
        if(coll.CompareTag("Player"))
        {
            if(firsTime)
            {
                firsTime = false;
                audioManager.PlaySFX(audioManager.creepyReflectionSFX);
                creepyReflection.SetActive(true);
                secondTrigger.SetActive(true);
            } 
        }
    }
}
