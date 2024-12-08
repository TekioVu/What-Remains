using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Raycast : MonoBehaviour
{
    public int range;

    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward, out hit, range)) 
        {
            if (hit.collider.isTrigger)
            {
                SecondTrigger secondTrigger = hit.collider.GetComponent<SecondTrigger>();
                ThirdTrigger thirdTrigger = hit.collider.GetComponent<ThirdTrigger>();

                if(secondTrigger != null) 
                {
                    secondTrigger.SecondTriggerDetected();
                    secondTrigger.gameObject.SetActive(false);
                } else if(thirdTrigger != null)
                {
                    thirdTrigger.ThirdTriggerDetected();
                    thirdTrigger.gameObject.SetActive(false);
                }

            }
        }
    }
}