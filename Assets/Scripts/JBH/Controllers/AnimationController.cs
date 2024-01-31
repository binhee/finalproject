using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : Animations
{
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");   // "IsWalking" �Ű� ���� �ؽ�
    private static readonly int Attack = Animator.StringToHash("Attack");        // "Attack" Ʈ���� �ؽ�
    private static readonly int IsHit = Animator.StringToHash("IsHit");           // "IsHit" �Ű� ���� �ؽ�

    private HealthSystem _healthSystem;   // ü�� �ý��� ������Ʈ

    protected override void Awake()
    {
        base.Awake();
        _healthSystem = GetComponent<HealthSystem>();   // ü�� �ý��� ������Ʈ ��������
    }

    void Start()
    {
        controller.OnAttackEvent += Attacking;   // ���� �̺�Ʈ�� ���� �Լ� ����
        controller.OnMoveEvent += Move;          // �̵� �̺�Ʈ�� �̵� �Լ� ����

        if (_healthSystem != null)
        {
            _healthSystem.OnDamage += Hit;                  // ������ �̺�Ʈ�� �ǰ� �Լ� ����
            _healthSystem.OnInvincibilityEnd += InvincibilityEnd;   // ���� ���� ���� �̺�Ʈ�� ���� ���� �Լ� ����
        }
    }

    // �̵� �̺�Ʈ���� ȣ��Ǵ� �Լ�
    private void Move(Vector2 movement)
    {
        animator.SetBool(IsWalking, movement.magnitude > 0.5f);   // �̵� ���ο� ���� �ִϸ��̼� ����
    }

    // ���� �̺�Ʈ���� ȣ��Ǵ� �Լ�
    private void Attacking(AttackSO attackSO)
    {
        animator.SetTrigger(Attack);   // ���� Ʈ���� ����
    }

    // �ǰ� �̺�Ʈ���� ȣ��Ǵ� �Լ�
    public void Hit()
    {
        animator.SetBool(IsHit, true);   // �ǰ� �ִϸ��̼� ����
    }

    // ���� ���� ���� �̺�Ʈ���� ȣ��Ǵ� �Լ�
    private void InvincibilityEnd()
    {
        animator.SetBool(IsHit, false);   // �ǰ� �ִϸ��̼� ����
    }
}