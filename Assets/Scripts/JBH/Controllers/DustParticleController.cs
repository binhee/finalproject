using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustParticleController : MonoBehaviour
{
    [SerializeField] private bool createDustOnWalk = true;   // 걷는 동안 먼지 효과 생성 여부
    [SerializeField] private ParticleSystem dustParticleSystem;   // 먼지 효과를 담은 파티클 시스템

    // 먼지 효과 생성 메서드
    public void CreateDustParticles()
    {
        if (createDustOnWalk)
        {
            dustParticleSystem.Stop();   // 파티클 시스템 정지
            dustParticleSystem.Play();   // 파티클 시스템 재생
        }
    }
}