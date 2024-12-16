using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightTrigger : MonoBehaviour
{
    [SerializeField] private GameObject darkAreas;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            darkAreas.SetActive(false);
        }
    }
}
