using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem; 
using UnityEngine;

public class PuzzleCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject puzzleUI;

    private CharacterController characterController;

    [SerializeField] private GameObject keyLockManagerHolder;
    [SerializeField] private GameObject keyButtonsMenuHolder;

    private KeyLockManager keyLockManager;
    private KeyButtonsMenu keyButtonsMenu;

    private void Start()
    {
        keyLockManager = keyLockManagerHolder.GetComponent<KeyLockManager>();
        keyButtonsMenu = keyButtonsMenuHolder.GetComponent<KeyButtonsMenu>();
    }

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

            if(keyLockManager.DoorLocked())
            {
                keyLockManager.RestartLocks();
                keyLockManager.RestartKeyButtons();
                keyButtonsMenu.RestartHandleKeys();
            }

            puzzleUI.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
