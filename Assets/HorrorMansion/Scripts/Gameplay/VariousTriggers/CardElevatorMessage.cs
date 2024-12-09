using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardElevatorMessage : MonoBehaviour
{
    [SerializeField] private GameObject audioManagerHolder;
    private AudioManager audioManager;

    private bool alreadyMessaged = false;

    private void Start()
    {
        audioManager = audioManagerHolder.GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !alreadyMessaged)
        {
            alreadyMessaged = true;
            audioManager.PlaySFX(audioManager.elevatorCard);
        }
        
    }
}
