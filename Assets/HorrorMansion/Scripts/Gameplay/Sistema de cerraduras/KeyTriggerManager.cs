using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTriggerManager : MonoBehaviour
{
    public bool AllKeysObtained()
    {
        int keysObtained = 0;

        for(int i = 0; i < transform.childCount; i++)
        {
            KeyTriggers keyTriggers = transform.GetChild(i).GetComponent<KeyTriggers>();
            if(keyTriggers.keyObtained) keysObtained++;
        }

        if(keysObtained == 5) return true;
        else return false;
    }
}
