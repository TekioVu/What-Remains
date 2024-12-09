using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorTrigger : MonoBehaviour
{
   [SerializeField] private GameObject audioManagerHolder;
   [SerializeField] private GameObject elevator;

    private AudioManager audioManager;

    void Start()
    {
        audioManager = audioManagerHolder.GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Animator animator = elevator.GetComponent<Animator>();
            animator.SetTrigger("Close");
            audioManager.PlaySFX(audioManager.elevatorNoise);
            StartCoroutine(GoNextScene());
        }
    }

    private IEnumerator GoNextScene()
    {
        yield return new WaitForSeconds(13f);
        SceneManager.LoadScene("GAME 2 (ELEVATOR)");

    }
}
