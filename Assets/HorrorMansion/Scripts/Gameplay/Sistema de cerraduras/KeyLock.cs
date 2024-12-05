using UnityEngine;

public class KeyLock : MonoBehaviour
{
    public Key.KeyType keyType;
    [SerializeField] private GameObject keyButtonsUI;
    public bool lockLocked = true;

    public Key.KeyType GetKeyType()
    {
        return keyType;
    }

    public void OpenKeyButtonsMenu()
    {
        if (keyButtonsUI.activeInHierarchy)
        {
            keyButtonsUI.SetActive(false);
        }
        else
        {
            // Pasar la referencia de este script al segundo panel.
            KeyButtonsMenu keyButtonsMenu = keyButtonsUI.GetComponent<KeyButtonsMenu>();
            keyButtonsMenu.SetParentKeyLock(this);

            keyButtonsUI.SetActive(true);
        }
    }
}
