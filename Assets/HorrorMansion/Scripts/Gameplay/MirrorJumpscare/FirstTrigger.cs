using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTrigger : MonoBehaviour
{
    [SerializeField] private GameObject creepyReflection;
    [SerializeField] private GameObject secondTrigger;

    private bool firstTime = true;

    public void OnTriggerEnter(Collider coll)
    {
        if(coll.CompareTag("Player"))
        {
            if(firstTime)
            {
                firstTime = false;
                creepyReflection.SetActive(true);
                secondTrigger.SetActive(true);
            }
            
        }
    }
}
