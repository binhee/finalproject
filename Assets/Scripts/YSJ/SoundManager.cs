using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [Header("---------- Audio Source -----------")]
    [SerializeField] AudioSource BGMSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip -----------")]
    public AudioClip BGM;
    public AudioClip BTNSound;



    private void Start()
    {
        // ������ ���۵� �� BGM ����
        BGMSource.clip = BGM;
        BGMSource.Play();
    }

    public void PlatSFX(AudioClip clip)     // ���ϴ� ���� ȿ�� ���(SFX)
    {
        SFXSource.PlayOneShot(clip);
    }
}
