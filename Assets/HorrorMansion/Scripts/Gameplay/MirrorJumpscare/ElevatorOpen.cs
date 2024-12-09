using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorOpen : MonoBehaviour
{
   [SerializeField] private GameObject audioManagerHolder;
   [SerializeField] private GameObject elevator;

    private AudioManager audioManager;
    private Animator elevatorAnimator;

    void Start()
    {
        audioManager = audioManagerHolder.GetComponent<AudioManager>();
        elevatorAnimator = elevator.GetComponent<Animator>();

        elevatorAnimator.SetTrigger("Open");
    }
}
