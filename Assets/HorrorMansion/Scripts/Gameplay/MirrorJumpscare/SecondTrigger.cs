using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondTrigger : MonoBehaviour
{
   [SerializeField] private GameObject creepyWomen;
   [SerializeField] private GameObject mirror;

    public void SecondTriggerDetected()
    {
        creepyWomen.SetActive(true);
        mirror.SetActive(false);
    }
}
