﻿using UnityEngine;
using UnityEngine.InputSystem;  // Añadir el nuevo namespace
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    bool trig, open;
    bool ePressed = false;
    public float smooth = 2.0f;
    public float DoorOpenAngle = 90.0f;
    public float rotationTolerance = 1.0f; // Tolerance for stopping rotation
    private Quaternion defaultRot;
    private Quaternion openRot;
    public Text txt;

    [SerializeField] private GameObject audioManagerHolder;
    private AudioManager audioManager;

    [SerializeField] private bool audioManagerNecessary = false;

    void Start()
    {
        defaultRot = transform.rotation;
        openRot = Quaternion.Euler(defaultRot.eulerAngles + Vector3.up * DoorOpenAngle);

        if(audioManagerNecessary)
        audioManager = audioManagerHolder.GetComponent<AudioManager>();
    }

    void Update()
    {
        if (ePressed && trig)
        {
            open = !open;
            ePressed = false;
        }

        if (open && Quaternion.Angle(transform.rotation, openRot) > rotationTolerance )
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, openRot, Time.deltaTime * smooth);
        }
        else if (!open && Quaternion.Angle(transform.rotation, defaultRot) > rotationTolerance)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, defaultRot, Time.deltaTime * smooth);
        }

        if (trig)
        {
            if (open)
            {
                txt.text = "Close [E]";
            }
            else
            {
                txt.text = "Open [E]";
            }
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            if (!open)
            {
                txt.text = "Close [E]";
            }
            else
            {
                txt.text = "Open [E]";
            }
            trig = true;
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            txt.text = " ";
            trig = false;
        }
    }

    private void OnTriggerStay(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            // Cambiar esta línea para usar el nuevo Input System
            if (Keyboard.current.eKey.wasPressedThisFrame)  // Nueva API
            {
                if(audioManagerNecessary)
                {
                    if(open) audioManager.PlaySFX(audioManager.openDoor);
                    else audioManager.PlaySFX(audioManager.closeDoor);
                }
                ePressed = true;
            }
        }
    }
}
