using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnTimer : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private string scene;

    void Update()
    {
        if(timer <= 0)
            SceneManager.LoadScene(scene);
        else timer -= Time.deltaTime;
    }
}
