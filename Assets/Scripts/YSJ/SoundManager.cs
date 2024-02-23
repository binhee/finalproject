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

    [Header("-----------Boss1Audio------------")]
    public AudioClip Boss1Pattern1Sound;
    public AudioClip Boss1Pattern2Sound;
    public AudioClip Boss1Pattern3Sound;
    public AudioClip Boss1Die;

    [Header("-----------Boss2Audio------------")]
    public AudioClip Boss2Pattern1Sound;
    public AudioClip Boss2Pattern2Sound;
    public AudioClip Boss2Pattern3Sound;
    public AudioClip Boss2Die;

    [Header("-----------Boss3Audio------------")]
   
    public AudioClip Boss3Pattern1Sound;
    public AudioClip Boss3Pattern2Sound;
    public AudioClip Boss3Pattern3Sound;
    public AudioClip Boss3Die;



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
