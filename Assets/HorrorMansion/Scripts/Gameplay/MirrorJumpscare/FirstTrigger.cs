using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTrigger : MonoBehaviour
{
    [SerializeField] private GameObject creepyReflection;

    public void FirstTriggerDetected()
    {
        creepyReflection.SetActive(true);
    }
}
