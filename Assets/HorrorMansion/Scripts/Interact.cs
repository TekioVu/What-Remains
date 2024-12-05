using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject LightObject;
    private bool lightOnOff;

    public void OnOffL()
    {
        lightOnOff = !lightOnOff;

        if (lightOnOff == true)
            LightObject.SetActive(true);
        if (lightOnOff == false)
            LightObject.SetActive(false);
    }
}
