using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider BGMSlider;
    [SerializeField] private Slider SFXSlider;

    private void Start()
    {
        SetBGMVolume();     // �����̴� ���� ����� �ͼ� ȣȯ.
        SetSFXVolume();
    }
    
    public void SetBGMVolume()
    {
        float volume = BGMSlider.value;
        audioMixer.SetFloat("BGM", Mathf.Log10(volume)*20);
    }
    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }

}
