using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip audioClip; // Assign  MP3 file in the Inspector

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // Press 'P' to play the audio
        {
            PlayAudio();
        }

        if (Input.GetKeyDown(KeyCode.S)) // Press 'S' to stop the audio
        {
            StopAudio();
        }
    }

    public void PlayAudio()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }

    public void StopAudio()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
}
