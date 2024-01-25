using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackController : MonoBehaviour
{
    [SerializeField] private LayerMask levelCollisionLayer;   // ���� �浹 ���̾� ����ũ

    private RangedAttackData _attackData;   // ���Ÿ� ���� ������
    private float _currentDuration;   // ���� ���� �ð�
    private Vector2 _direction;   // �߻� ����
    private bool _isReady;   // �߻�ü�� �غ�� �������� ����

    private Rigidbody2D _rigidbody;   // Rigidbody2D ������Ʈ
    private SpriteRenderer _spriteRenderer;   // SpriteRenderer ������Ʈ
    private TrailRenderer _trailRenderer;   // TrailRenderer ������Ʈ
    private ProjectileManager _projectManager;   // ProjectileManager

    public bool fxOnDestroy = true;   // �߻�ü�� �ı��� �� ����Ʈ�� �������� ����

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();   // �ڽ� ��ü �� SpriteRenderer ������Ʈ ��������
        _rigidbody = GetComponent<Rigidbody2D>();   // Rigidbody2D ������Ʈ ��������
        _trailRenderer = GetComponent<TrailRenderer>();   // TrailRenderer ������Ʈ ��������
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
        // ���� �߻�ü�� �浹���� ��
        if (levelCollisionLayer.value == (levelCollisionLayer.value | (1 << collision.gameObject.layer)))
        {
            DestroyProjectile(collision.ClosestPoint(transform.position) - _direction * 0.2f, fxOnDestroy);
        }
        // ��� ���̾�� �浹���� ��
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

    // ���Ÿ� ���� �ʱ�ȭ
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

    // �߻�ü�� ��������Ʈ ������Ʈ
    private void UpdateProjectileSprite()
    {
        transform.localScale = Vector3.one * _attackData.size;
    }

    // �߻�ü �ı�
    private void DestroyProjectile(Vector3 position, bool createFx)
    {
        if (createFx)
        {
            _projectManager.CreateImpactParticlesAtPosition(position, _attackData);
        }
        gameObject.SetActive(false);
    }
}