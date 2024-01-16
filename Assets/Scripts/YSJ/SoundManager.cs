using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource btnSource;

    public void SetBGMVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void SetBtnVolume(float volume)
    {
        btnSource.volume = volume;
    }

    public void OnButtonSound()
    {
        btnSource.Play();
    }
}
