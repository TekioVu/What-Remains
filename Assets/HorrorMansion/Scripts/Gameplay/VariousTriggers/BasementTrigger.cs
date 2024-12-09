using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementTrigger : MonoBehaviour
{
    [SerializeField] private GameObject audioManagerHolder;
    [SerializeField] private GameObject basementDoors;

    private AudioManager audioManager;

    void Start()
    {
        audioManager = audioManagerHolder.GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.basementDoors);
            basementDoors.SetActive(true);
            gameObject.SetActive(false);
        }

    }
}
