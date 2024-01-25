using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;      // 이동 이벤트
    public event Action<Vector2> OnLookEvent;      // 바라보는 방향 변경 이벤트
    public event Action<AttackSO> OnAttackEvent;   // 공격 이벤트

    private float _timeSinceLastAttack = float.MaxValue;   // 마지막 공격 후 경과 시간
    protected bool IsAttacking { get; set; }               // 현재 공격 중 여부

    protected CharacterStatsHandler Stats { get; private set; }  // 캐릭터 스탯 핸들러

    protected virtual void Awake()
    {
        Stats = GetComponent<CharacterStatsHandler>();   // 캐릭터 스탯 핸들러 컴포넌트 가져오기
    }

    protected virtual void Update()
    {
        HandleAttackDelay();   // 공격 딜레이 처리
    }

    // 공격 딜레이를 처리하는 메서드
    private void HandleAttackDelay()
    {
        if (Stats.CurrentStats.attackSO == null)
            return;

        if (_timeSinceLastAttack <= Stats.CurrentStats.attackSO.delay)
        {
            _timeSinceLastAttack += Time.deltaTime;
        }
        if (IsAttacking && _timeSinceLastAttack > Stats.CurrentStats.attackSO.delay)
        {
            _timeSinceLastAttack = 0;
            CallAttackEvent(Stats.CurrentStats.attackSO);   // 공격 이벤트 호출
        }
    }

    // 이동 이벤트 호출 메서드
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    // 바라보는 방향 변경 이벤트 호출 메서드
    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    // 공격 이벤트 호출 메서드
    public void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }
}