using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem; 
using UnityEngine;

public class PuzzleCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject puzzleUI;
    private CharacterController characterController;

    public void CameraActivated()
    {
        characterController = player.GetComponent<CharacterController>();
        characterController.enabled = false;

        puzzleUI.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if(Keyboard.current.eKey.wasPressedThisFrame)
        {
            characterController.enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            puzzleUI.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
