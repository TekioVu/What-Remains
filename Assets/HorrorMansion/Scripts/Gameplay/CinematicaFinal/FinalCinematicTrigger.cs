using UnityEngine;
using UnityEngine.Playables;
using UHFPS.Runtime;

public class FinalCinematicTrigger : MonoBehaviour
{
    [SerializeField] private PlayableDirector cutscene; 
    [SerializeField] private AudioSource musicAudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            musicAudioSource.Stop();
            cutscene.Play();  
            gameObject.SetActive(false);
        }
    }
}
