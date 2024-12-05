using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{
    [SerializeField] private GameObject puzzleCamera;
    [SerializeField] private GameObject puzzleUI;

    private void OnTriggerEnter()
    {
        puzzleCamera.SetActive(true);
        puzzleUI.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
