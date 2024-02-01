using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _impactParticleSystem;  // ����ü �ǰ� ����Ʈ�� ���� ��ƼŬ �ý���
    [SerializeField] public ParticleSystem dieEffect;  //�׾����� ��ƼŬ ȿ��.

    public static ProjectileManager Instance;   // �̱��� �ν��Ͻ�

    private ObjectPool objectPool;   // ������Ʈ Ǯ

    private void Awake()
    {
        Instance = this;   // �̱��� �ν��Ͻ� �ʱ�ȭ
    }

    void Start()
    {
        objectPool = GetComponent<ObjectPool>();   // ������Ʈ Ǯ ������Ʈ ��������
    }

    // ����ü �߻� �޼���
    public void ShootBullet(Vector2 startPosition, Vector2 direction, RangedAttackData attackData)
    {
        GameObject obj = objectPool.SpawnFromPool(attackData.bulletNameTag);   // ������Ʈ Ǯ���� ����ü ��������

        obj.transform.position = startPosition;   // ����ü�� ���� ��ġ ����
        RangedAttackController attackController = obj.GetComponent<RangedAttackController>();   // ����ü ��Ʈ�ѷ� ������Ʈ ��������
        attackController.InitializeAttack(direction, attackData, this);   // ����ü �ʱ�ȭ

        obj.SetActive(true);   // ����ü Ȱ��ȭ
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