using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustParticleController : MonoBehaviour
{
    [SerializeField] private bool createDustOnWalk = true;   // �ȴ� ���� ���� ȿ�� ���� ����
    [SerializeField] private ParticleSystem dustParticleSystem;   // ���� ȿ���� ���� ��ƼŬ �ý���

    // ���� ȿ�� ���� �޼���
    public void CreateDustParticles()
    {
        if (createDustOnWalk)
        {
            dustParticleSystem.Stop();   // ��ƼŬ �ý��� ����
            dustParticleSystem.Play();   // ��ƼŬ �ý��� ���
        }
    }
}