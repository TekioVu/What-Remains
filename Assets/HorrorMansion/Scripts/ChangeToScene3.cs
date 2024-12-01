using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class ChangeToScene3 : MonoBehaviour
{
    public PlayableDirector cutsceneToPlay;

    public void ChangeScene()
    {
        SceneManager.LoadScene("Cutscene_3");
    }

    public void ChangeCutscene()
    {
        cutsceneToPlay.Play();
    }
}
