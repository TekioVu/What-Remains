using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
   [SerializeField] private GameObject audioManagerHolder;
   private AudioManager audioManager;

   [SerializeField] private AudioClip audioClip;

    private void Start()
    {
        audioManager = audioManagerHolder.GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioClip);
            gameObject.SetActive(false);
        }
    }
}
