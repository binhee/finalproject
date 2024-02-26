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
        _controller.OnAttackEvent += OnShoot;  // 공격 이벤트에 샷 발사 함수 연결
        _controller.OnLookEvent += OnAim;     // 바라보는 방향 변경 이벤트에 바라보는 방향 갱신 함수 연결
    }

    // 바라보는 방향 갱신 이벤트에서 호출되는 함수
    private void OnAim(Vector2 newAimDirection)
    {
        _aimDirection = newAimDirection;  // 바라보는 방향 갱신
    }

    // 공격 이벤트에서 호출되는 함수5
    private void OnShoot(AttackSO attackSO)
    {
        RangedAttackData rangedAttackData = attackSO as RangedAttackData;
        float projectilesAngleSpace = rangedAttackData.multipleProjectilesAngel;  // 발사된 탄환들의 간격
        int numberOfProjectilesPerShot = rangedAttackData.numberofProjectilesPerShot;  // 발사될 탄환의 수

        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * rangedAttackData.multipleProjectilesAngel;

        // 여러 탄환을 발사하는 반복문
        for (int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            SoundManager.SoundInstance.PlaySFX(SoundManager.SoundInstance.AttackSound);
            float angle = minAngle + projectilesAngleSpace * i;
            float randomSpread = Random.Range(-rangedAttackData.spread, rangedAttackData.spread);
            angle += randomSpread;
            CreateProjectile(rangedAttackData, angle);
        }
    }

    // 탄환을 생성하는 함수
    private void CreateProjectile(RangedAttackData rangedAttackData, float angle)
    {
        _projectileManager.ShootBullet(projectileSpawnPosition.position, RotateVector2(_aimDirection, angle), rangedAttackData);
    }

    // 2D 벡터를 주어진 각도로 회전시키는 함수
    private static Vector2 RotateVector2(Vector2 v, float degree)
    {
        return Quaternion.Euler(0, 0, degree) * v;
    }
}