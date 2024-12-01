using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToScene3 : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("Cutscene_3");
    }
}
