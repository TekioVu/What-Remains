using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLockManager : MonoBehaviour
{
    public bool doorLocked()
    {
        int openCount = 0;

        for(int i = 0; i < transform.childCount; i++)
        {
            KeyLock keylock = transform.GetChild(i).GetComponent<KeyLock>();
            if(!keylock.lockLocked)
                openCount++;
        }

        if(openCount == 5) 
            return false;
        else
            return true;
    }


}
