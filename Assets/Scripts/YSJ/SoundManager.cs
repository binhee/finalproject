using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager SoundInstance;

    [Header("---------- Audio Source -----------")]
    [SerializeField] AudioSource BGMSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip -----------")]
    public AudioClip BGM;
    public AudioClip BTNSound;
    public AudioClip AttackSound;
    public AudioClip JumpSound;
    public AudioClip DieSound;


    public AudioClip AppearSound;
    public AudioClip Pattern2Sound;
    public AudioClip Pattern3Sound;
    public AudioClip Boss1Die;


    private void Awake()
    {
        SoundInstance = this;
    }

    private void Start()
    {
        // ������ ���۵� �� BGM ����
        BGMSource.clip = BGM;
        BGMSource.Play();
    }

    public void PlaySFX(AudioClip clip)     // ���ϴ� ���� ȿ�� ���(SFX)
    {
        SFXSource.PlayOneShot(clip);
    }
}
