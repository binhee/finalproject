using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _impactParticleSystem;  // ����ü �ǰ� ����Ʈ�� ���� ��ƼŬ �ý���
    [SerializeField] public ParticleSystem dieEffect;  //�׾����� ��ƼŬ ȿ��.

    public static ProjectileManager Instance;   // �̱��� �ν��Ͻ�

    private PlayerAttackObjectPool objectPool;   // ������Ʈ Ǯ

    private void Awake()
    {
        Instance = this;   // �̱��� �ν��Ͻ� �ʱ�ȭ
    }

    void Start()
    {
        objectPool = GetComponent<PlayerAttackObjectPool>();   // ������Ʈ Ǯ ������Ʈ ��������
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

    // ����ü �ǰ� ����Ʈ ���� �޼���
    public void CreateImpactParticlesAtPosition(Vector3 position, RangedAttackData attackData)
    {
        _impactParticleSystem.transform.position = position;   // ����Ʈ ��ġ ����
        ParticleSystem.EmissionModule em = _impactParticleSystem.emission;
        em.SetBurst(0, new ParticleSystem.Burst(0, Mathf.Ceil(attackData.size * 5)));   // ����Ʈ ��ƼŬ �� ����
        ParticleSystem.MainModule mainModule = _impactParticleSystem.main;
        mainModule.startSpeedMultiplier = attackData.size * 10f;   // ����Ʈ �ӵ� ����
        _impactParticleSystem.Play();   // ����Ʈ ���
    }
}