using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondTrigger : MonoBehaviour
{
   [SerializeField] private GameObject creepyWomen;
   [SerializeField] private GameObject creepyReflection;
   [SerializeField] private GameObject mirror;
   [SerializeField] private GameObject thirdTrigger;

    public void SecondTriggerDetected()
    {
        creepyReflection.SetActive(false);
        creepyWomen.SetActive(true);
        mirror.SetActive(false);
        thirdTrigger.SetActive(true);
    }
}
