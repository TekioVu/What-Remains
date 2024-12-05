using UnityEngine;

public class KeyButtonsMenu : MonoBehaviour
{
    private KeyLock parentKeyLock;

    // Método para establecer el padre.
    public void SetParentKeyLock(KeyLock keyLock)
    {
        parentKeyLock = keyLock;
    }


    public void IntroduceKey(string introducedKeyType)
    {
        // Playear animación.

        if (parentKeyLock != null)
        {
            if (introducedKeyType == parentKeyLock.keyType.ToString())
            {
                parentKeyLock.lockLocked = false;
            }
        }
        else
        {
            Debug.LogWarning("No se ha asignado el KeyLock padre.");
        }
    }
}
