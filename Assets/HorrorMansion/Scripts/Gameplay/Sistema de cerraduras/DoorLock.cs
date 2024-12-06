using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    [SerializeField] private GameObject[] keys;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ActivateKeyAnimation(int i)
    {
        keys[i].SetActive(true);
        animator.SetTrigger("IntroduceKey");
    }
}
