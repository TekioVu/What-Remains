using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public enum KeyColor{
        PURPLE,
        RED,
        ORANGE,
        YELLOW,
        BLUE,
        LAST_ELEMENT
    }

    private bool[] keysObtained = new bool[(int)KeyColor.LAST_ELEMENT];
    public bool AllKeysObtained()
    {
        for(int i = 0; i < keysObtained.Length; i++)
        {
            if(!keysObtained[i]) return false;
        }

        return true;
    }

    public void ObtainKey(int color)
    {
        keysObtained[color] = true;
    }

}
