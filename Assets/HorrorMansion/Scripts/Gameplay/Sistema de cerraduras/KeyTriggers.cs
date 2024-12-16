using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTriggers : MonoBehaviour
{ 
    [SerializeField] private GameObject darkAreas;

    public bool keyObtained = false;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            keyObtained = true;
        }
    }
}
