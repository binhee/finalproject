using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : Animations
{
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");   // "IsWalking" 매개 변수 해시
    private static readonly int Attack = Animator.StringToHash("Attack");        // "Attack" 트리거 해시
    private static readonly int IsHit = Animator.StringToHash("IsHit");           // "IsHit" 매개 변수 해시

    private HealthSystem _healthSystem;   // 체력 시스템 컴포넌트

    protected override void Awake()
    {
        base.Awake();
        _healthSystem = GetComponent<HealthSystem>();   // 체력 시스템 컴포넌트 가져오기
    }

    void Start()
    {
        controller.OnAttackEvent += Attacking;   // 공격 이벤트에 공격 함수 연결
        controller.OnMoveEvent += Move;          // 이동 이벤트에 이동 함수 연결

        if (_healthSystem != null)
        {
            _healthSystem.OnDamage += Hit;                  // 데미지 이벤트에 피격 함수 연결
            _healthSystem.OnInvincibilityEnd += InvincibilityEnd;   // 무적 상태 종료 이벤트에 무적 종료 함수 연결
        }
    }

    // 이동 이벤트에서 호출되는 함수
    private void Move(Vector2 movement)
    {
        animator.SetBool(IsWalking, movement.magnitude > 0.5f);   // 이동 여부에 따라 애니메이션 설정
    }

    // 공격 이벤트에서 호출되는 함수
    private void Attacking(AttackSO attackSO)
    {
        animator.SetTrigger(Attack);   // 공격 트리거 설정
    }

    // 피격 이벤트에서 호출되는 함수
    public void Hit()
    {
        animator.SetBool(IsHit, true);   // 피격 애니메이션 설정
    }

    // 무적 상태 종료 이벤트에서 호출되는 함수
    private void InvincibilityEnd()
    {
        animator.SetBool(IsHit, false);   // 피격 애니메이션 종료
    }
}