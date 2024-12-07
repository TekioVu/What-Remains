using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class KeyButtonsMenu : MonoBehaviour
{
    private KeyLock parentKeyLock;

    [SerializeField] private GameObject[] doorLocks;
    [SerializeField] private GameObject puzzleCameraHolder;
    [SerializeField] private GameObject audioManagerHolder;

    private Dictionary<string, int> keyToDoorMap;

    public int introducedKeys = 0;

    private PuzzleCamera puzzleCamera;
    private AudioManager audioManager;

    public int failsUntilMessage = 0;

    void Start()
    {
        keyToDoorMap = new Dictionary<string, int>
        {
            { "Purple", 0 },
            { "Red", 1 },
            { "Orange", 2 },
            { "Yellow", 3 },
            { "Blue", 4 }
        };

        puzzleCamera = puzzleCameraHolder.GetComponent<PuzzleCamera>();
        audioManager = audioManagerHolder.GetComponent<AudioManager>();
    }

    public void SetParentKeyLock(KeyLock keyLock)
    {
        parentKeyLock = keyLock;
    }


    public void IntroduceKey(string introducedKeyType)
    {
        audioManager.PlaySFX(audioManager.introduceKey);
        SearchDoorHandle(parentKeyLock.keyType.ToString(), introducedKeyType);

        if (introducedKeyType == parentKeyLock.keyType.ToString())
        {
            parentKeyLock.lockLocked = false;
        }

        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        if (clickedButton != null)
        {
            clickedButton.SetActive(false); 
        }
        parentKeyLock.gameObject.SetActive(false);

        introducedKeys++;
        if(introducedKeys == 5)
        {
            audioManager.PlaySFX(audioManager.lockedDoor);
            
            if(failsUntilMessage == 0)
            {
                audioManager.PlaySFX(audioManager.specificCombination);
                failsUntilMessage = 2;
            } else failsUntilMessage--;   
        
            puzzleCamera.ExitPuzzle();
        }

        gameObject.SetActive(false);
    }

    private void SearchDoorHandle(string parentKeyLock, string introducedKeyType)
    {
        if (keyToDoorMap.TryGetValue(parentKeyLock, out int doorIndex))
        {
            DoorLock doorLock = doorLocks[doorIndex].GetComponent<DoorLock>();

            if(keyToDoorMap.TryGetValue(introducedKeyType, out int keyIndex))
            doorLock.ActivateKeyAnimation(keyIndex);
        }
    }

    public void RestartHandleKeys()
    {
        for(int i = 0; i < doorLocks.Length; i++)
        {
            DoorLock doorLock = doorLocks[i].GetComponent<DoorLock>();
            doorLock.RestartKeys();

            Animator anim = doorLock.gameObject.GetComponent<Animator>();
            anim.SetBool("IntroduceKey", false);
        }
        introducedKeys = 0;

        gameObject.SetActive(false);
    }
}
