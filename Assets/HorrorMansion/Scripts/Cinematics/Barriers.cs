using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barriers : MonoBehaviour
{
    [SerializeField] private GameObject textBox;
    private AudioManager audioManager;
    private bool alreadyMessaged = false;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    
    private IEnumerator PrintMessage()
    {
        textBox.SetActive(true);
        audioManager.PlaySFX(audioManager.professorWaiting);
        yield return new WaitForSeconds(4f);
        textBox.SetActive(false);
    }

    private IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(10f);
        alreadyMessaged = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!alreadyMessaged)
        {
            StartCoroutine(PrintMessage());
            alreadyMessaged = true;
            StartCoroutine(ResetCooldown());
        }
    }
}
