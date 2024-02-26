using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private ProjectileManager _projectileManager;
    private PlayerController _controller;

    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 _aimDirection = Vector2.right;

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
    }

    void Start()
    {
        _projectileManager = ProjectileManager.Instance;
        _controller.OnAttackEvent += OnShoot;  // ���� �̺�Ʈ�� �� �߻� �Լ� ����
        _controller.OnLookEvent += OnAim;     // �ٶ󺸴� ���� ���� �̺�Ʈ�� �ٶ󺸴� ���� ���� �Լ� ����
    }

    // �ٶ󺸴� ���� ���� �̺�Ʈ���� ȣ��Ǵ� �Լ�
    private void OnAim(Vector2 newAimDirection)
    {
        _aimDirection = newAimDirection;  // �ٶ󺸴� ���� ����
    }

    // ���� �̺�Ʈ���� ȣ��Ǵ� �Լ�5
    private void OnShoot(AttackSO attackSO)
    {
        RangedAttackData rangedAttackData = attackSO as RangedAttackData;
        float projectilesAngleSpace = rangedAttackData.multipleProjectilesAngel;  // �߻�� źȯ���� ����
        int numberOfProjectilesPerShot = rangedAttackData.numberofProjectilesPerShot;  // �߻�� źȯ�� ��

        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * rangedAttackData.multipleProjectilesAngel;

        // ���� źȯ�� �߻��ϴ� �ݺ���
        for (int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            SoundManager.SoundInstance.PlaySFX(SoundManager.SoundInstance.AttackSound);
            float angle = minAngle + projectilesAngleSpace * i;
            float randomSpread = Random.Range(-rangedAttackData.spread, rangedAttackData.spread);
            angle += randomSpread;
            CreateProjectile(rangedAttackData, angle);
        }
    }

    // źȯ�� �����ϴ� �Լ�
    private void CreateProjectile(RangedAttackData rangedAttackData, float angle)
    {
        _projectileManager.ShootBullet(projectileSpawnPosition.position, RotateVector2(_aimDirection, angle), rangedAttackData);
    }

    // 2D ���͸� �־��� ������ ȸ����Ű�� �Լ�
    private static Vector2 RotateVector2(Vector2 v, float degree)
    {
        return Quaternion.Euler(0, 0, degree) * v;
    }
}