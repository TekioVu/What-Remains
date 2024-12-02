using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene2SR : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject oldProfessor;
    [SerializeField] private GameObject newProfessor;

    [SerializeField] private GameObject[] food;

    private CharacterController characterController;

    private void Start()
    {
        characterController = player.GetComponent<CharacterController>();
    }

    public void EnableCharacterController()
    {
        characterController.enabled = true;
    }

    public void EndCinematic2()
    {
        oldProfessor.SetActive(false);
        newProfessor.SetActive(true);
    }

    public void HideFood()
    {
        for(int i = 0; i < food.Length; i++)
        {
            food[i].SetActive(false);
        }
    }
}
