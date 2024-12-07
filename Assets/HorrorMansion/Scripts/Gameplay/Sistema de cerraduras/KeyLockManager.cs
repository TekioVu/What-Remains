using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLockManager : MonoBehaviour
{
    [SerializeField] private GameObject[] keysButtons;
    [SerializeField] private GameObject audioManagerHolder;
    private AudioManager audioManager;

    private bool alreadyPlayedSFX = false;

    private void Start()
    {
        audioManager = audioManagerHolder.GetComponent<AudioManager>();
    }

    public bool DoorLocked()
    {
        int openCount = 0;

        for(int i = 0; i < transform.childCount; i++)
        {
            KeyLock keylock = transform.GetChild(i).GetComponent<KeyLock>();
            if(!keylock.lockLocked)
                openCount++;
        }

        if(openCount == 5) 
        {
            if(!alreadyPlayedSFX)
            {
                alreadyPlayedSFX = true;
                audioManager.PlaySFX(audioManager.openLockedDoor);
            }
            return false;
        }
        else
            return true;
    }

    public void RestartLocks()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            KeyLock keylock = transform.GetChild(i).GetComponent<KeyLock>();
            keylock.lockLocked = true;
            keylock.gameObject.SetActive(true);
        }
    }

    public void RestartKeyButtons()
    {
        for(int i = 0; i < keysButtons.Length; i++)
        {
            keysButtons[i].SetActive(true);
        }
    }
}
