using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _impactParticleSystem;  // 투사체 피격 이펙트를 담은 파티클 시스템
    [SerializeField] public ParticleSystem dieEffect;  //죽었을때 파티클 효과.

    public static ProjectileManager Instance;   // 싱글톤 인스턴스

    private PlayerAttackObjectPool objectPool;   // 오브젝트 풀

    private void Awake()
    {
        Instance = this;   // 싱글톤 인스턴스 초기화
    }

    void Start()
    {
        objectPool = GetComponent<PlayerAttackObjectPool>();   // 오브젝트 풀 컴포넌트 가져오기
    }

    public class Projectile : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Ground"))
            {
                gameObject.SetActive(false);
            }
        }
    }

    // 투사체 피격 이펙트 생성 메서드
    public void CreateImpactParticlesAtPosition(Vector3 position, RangedAttackData attackData)
    {
        _impactParticleSystem.transform.position = position;   // 이펙트 위치 설정
        ParticleSystem.EmissionModule em = _impactParticleSystem.emission;
        em.SetBurst(0, new ParticleSystem.Burst(0, Mathf.Ceil(attackData.size * 5)));   // 이펙트 파티클 수 설정
        ParticleSystem.MainModule mainModule = _impactParticleSystem.main;
        mainModule.startSpeedMultiplier = attackData.size * 10f;   // 이펙트 속도 설정
        _impactParticleSystem.Play();   // 이펙트 재생
    }
}