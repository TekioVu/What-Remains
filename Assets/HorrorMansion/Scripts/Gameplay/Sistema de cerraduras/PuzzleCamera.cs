using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem; 
using UnityEngine;

public class PuzzleCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject puzzleUI;

    [SerializeField] private GameObject keyLockManagerHolder;
    [SerializeField] private GameObject keyButtonsMenuHolder;
    [SerializeField] private GameObject puzzleDoorHolder;

    private KeyLockManager keyLockManager;
    private KeyButtonsMenu keyButtonsMenu;
    private PuzzleDoor puzzleDoor;

    private void Start()
    {
        keyLockManager = keyLockManagerHolder.GetComponent<KeyLockManager>();
        keyButtonsMenu = keyButtonsMenuHolder.GetComponent<KeyButtonsMenu>();
        puzzleDoor = puzzleDoorHolder.GetComponent<PuzzleDoor>();
    }

    public void CameraActivated()
    {
        player.SetActive(false);

        puzzleUI.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if(Keyboard.current.eKey.wasPressedThisFrame)
        {
            ExitPuzzle();
        }
    }

    public void ExitPuzzle()
    {
        player.SetActive(true);
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
