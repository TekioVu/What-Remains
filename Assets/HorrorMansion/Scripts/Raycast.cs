using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public int range;
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward, out hit, range)) 
        {
            if (hit.collider.GetComponent<Interact>() == true) 
            {
                if (Input.GetKeyDown(KeyCode.E)) 
                {
                    hit.collider.GetComponent<Interact>().OnOffL();
                }
            }
        }
    }
}
