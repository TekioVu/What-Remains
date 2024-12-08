using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{    
    [Header("---------Audio Source---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    
    [Header("---------Audio Clip---------")]
    public AudioClip background;

    public AudioClip professorWaiting;

    public AudioClip openLockedDoor;
    public AudioClip lockedDoor;
    public AudioClip introduceKey;

    public AudioClip openDoor;
    public AudioClip closeDoor;

    public AudioClip specificCombination;
    public AudioClip tooDark;
    public AudioClip needToFindKeys;

    public AudioClip creepyReflectionSFX;

    public void Start(){
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    
}
