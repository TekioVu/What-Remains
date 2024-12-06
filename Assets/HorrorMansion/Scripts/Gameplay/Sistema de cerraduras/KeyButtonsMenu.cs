using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class KeyButtonsMenu : MonoBehaviour
{
    private KeyLock parentKeyLock;
    [SerializeField] private GameObject[] doorLocks;

    private Dictionary<string, int> keyToDoorMap;

    void Start()
    {
        // Inicializa el diccionario que asocia colores de llaves con índices de cerraduras.
        keyToDoorMap = new Dictionary<string, int>
        {
            { "Purple", 0 },
            { "Red", 1 },
            { "Orange", 2 },
            { "Yellow", 3 },
            { "Blue", 4 }
        };
    }

    public void SetParentKeyLock(KeyLock keyLock)
    {
        parentKeyLock = keyLock;
    }


    public void IntroduceKey(string introducedKeyType)
    {
        SearchDoorHandle(parentKeyLock.keyType.ToString(), introducedKeyType);

        if (introducedKeyType == parentKeyLock.keyType.ToString())
        {
            parentKeyLock.lockLocked = false;
        }

        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        if (clickedButton != null)
        {
            clickedButton.SetActive(false); // Oculta el botón
        }

        parentKeyLock.gameObject.SetActive(false);

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
}
