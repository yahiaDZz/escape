using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public float delay = 2f; 
     private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("PlayDelayedSound", delay);
    }

    private void PlayDelayedSound()
    {
        audioSource.Play();
    }
}
