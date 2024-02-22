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
        // 게임이 시작될 때 BGM 실행
        BGMSource.clip = BGM;
        BGMSource.Play();
    }

    public void PlaySFX(AudioClip clip)     // 원하는 사운드 효과 재생(SFX)
    {
        SFXSource.PlayOneShot(clip);
    }
}
