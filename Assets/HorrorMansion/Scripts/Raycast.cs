using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Raycast : MonoBehaviour
{
    public int range;
    private float lastInteractionTime = 0f;
    private float interactionCooldown = 0.5f;
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward, out hit, range)) 
        {
            if (hit.collider.GetComponent<Interact>() == true) 
            {
                
                if (Keyboard.current.eKey.wasPressedThisFrame && Time.time - lastInteractionTime > interactionCooldown) 
                {
                    lastInteractionTime = Time.time;
                    Interact interact = hit.collider.GetComponent<Interact>();
                    interact.OnOffL();
                }
            }
        }
    }
}
