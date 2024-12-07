using UnityEngine;
using UnityEngine.Playables;
using UHFPS.Runtime;

public class CutsceneTriggerHomemade : MonoBehaviour
{
    public PlayableDirector cutscene; 
    private CharacterController characterController;

    private bool hasPlayed = false; 

    void Start()
    {
        characterController = FindObjectOfType<PlayerManager>().GetComponent<CharacterController>();

        if (cutscene != null)
        {
            cutscene.Stop(); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            hasPlayed = true; 
            characterController.enabled = false;
            cutscene.Play();  
        }
    }
}
