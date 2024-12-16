using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGeneratorLight : MonoBehaviour
{
    [SerializeField] private GameObject[] light;
    [SerializeField] private GameObject houseCollider;

    public void Encenderluces() 
    {
        for (int i = 0; i < light.Length; i++)
        {
            light[i].SetActive(true);
        }

        houseCollider.SetActive(false);
    } 

}
