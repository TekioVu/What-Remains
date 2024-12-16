using UnityEngine;
using UnityEngine.Playables;
using UHFPS.Runtime;

public class StopMusic : MonoBehaviour
{
    [SerializeField] private PlayableDirector cutscene; 

    public void StopPreviousCutscene()
    {
        cutscene.Stop();  
    }
}
