using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ThirdTrigger : MonoBehaviour
{
    [SerializeField] private PlayableDirector playableDirector;

    public void ThirdTriggerDetected()
    {
       playableDirector.Play();
    }

}
