using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject LightObject;
    private bool lightOnOff = false;

    public void OnOffL()
    {
        lightOnOff = !lightOnOff;

        if (lightOnOff == true)
            LightObject.SetActive(true);
        else 
            LightObject.SetActive(false);
        Debug.Log(lightOnOff);
    }
}
