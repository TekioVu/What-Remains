using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSystem : MonoBehaviour
{
    [SerializeField] private GameObject elevatorButton;

    public void EnableButton()
    {
        BoxCollider boxCollider = elevatorButton.GetComponent<BoxCollider>();
        boxCollider.enabled = true;
    }
}
