using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackController : MonoBehaviour
{
    [SerializeField] private LayerMask levelCollisionLayer;   // 레벨 충돌 레이어 마스크

    private RangedAttackData _attackData;   // 원거리 공격 데이터
    private float _currentDuration;   // 현재 지속 시간
    private Vector2 _direction;   // 발사 방향
    private bool _isReady;   // 발사체가 준비된 상태인지 여부

    private Rigidbody2D _rigidbody;   // Rigidbody2D 컴포넌트
    private SpriteRenderer _spriteRenderer;   // SpriteRenderer 컴포넌트
    private TrailRenderer _trailRenderer;   // TrailRenderer 컴포넌트
    private ProjectileManager _projectManager;   // ProjectileManager

    public bool fxOnDestroy = true;   // 발사체가 파괴될 때 이펙트를 생성할지 여부

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();   // 자식 객체 중 SpriteRenderer 컴포넌트 가져오기
        _rigidbody = GetComponent<Rigidbody2D>();   // Rigidbody2D 컴포넌트 가져오기
        _trailRenderer = GetComponent<TrailRenderer>();   // TrailRenderer 컴포넌트 가져오기
    }

    private void Update()
    {
        if (!_isReady)
        {
            return;
        }

        _currentDuration += Time.deltaTime;

        if (_currentDuration > _attackData.duration)
        {
            DestroyProjectile(transform.position, false);
        }

        _rigidbody.velocity = _direction * _attackData.speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 벽과 발사체가 충돌했을 때
        if (levelCollisionLayer.value == (levelCollisionLayer.value | (1 << collision.gameObject.layer)))
        {
            DestroyProjectile(collision.ClosestPoint(transform.position) - _direction * 0.2f, fxOnDestroy);
        }
        // 대상 레이어와 충돌했을 때
        else if (_attackData.target.value == (_attackData.target.value | (1 << collision.gameObject.layer)))
        {
            HealthSystem healthSystem = collision.GetComponent<HealthSystem>();
            if (healthSystem != null)
            {
                healthSystem.ChangeHealth(-_attackData.power);
            }

            DestroyProjectile(collision.ClosestPoint(transform.position), fxOnDestroy);
        }
    }

    // 원거리 공격 초기화
    public void InitializeAttack(Vector2 direction, RangedAttackData attackData, ProjectileManager projectileManager)
    {
        _projectManager = projectileManager;
        _attackData = attackData;
        _direction = direction;

        _trailRenderer.Clear();
        _currentDuration = 0;
        _spriteRenderer.color = attackData.projectileColor;

        transform.right = direction;

        UpdateProjectileSprite();

        _isReady = true;
    }

    // 발사체의 스프라이트 업데이트
    private void UpdateProjectileSprite()
    {
        transform.localScale = Vector3.one * _attackData.size;
    }

    // 발사체 파괴
    private void DestroyProjectile(Vector3 position, bool createFx)
    {
        if (createFx)
        {
            _projectManager.CreateImpactParticlesAtPosition(position, _attackData);
        }
        gameObject.SetActive(false);
    }
}