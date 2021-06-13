using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SoundPlayer : MonoBehaviour
{
    GMTKControls controls;
    public AudioClip clip;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayClip();
    }
    public void PlayClip()
    {
        audioSource.pitch = (Random.Range(0.5f,1.3f));
        audioSource.PlayOneShot(clip, 1);
    }
}
