using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;      // �̵� �̺�Ʈ
    public event Action<Vector2> OnLookEvent;      // �ٶ󺸴� ���� ���� �̺�Ʈ
    public event Action<AttackSO> OnAttackEvent;   // ���� �̺�Ʈ

    private float _timeSinceLastAttack = float.MaxValue;   // ������ ���� �� ��� �ð�
    protected bool IsAttacking { get; set; }               // ���� ���� �� ����

    protected CharacterStatsHandler Stats { get; private set; }  // ĳ���� ���� �ڵ鷯

    protected virtual void Awake()
    {
        Stats = GetComponent<CharacterStatsHandler>();   // ĳ���� ���� �ڵ鷯 ������Ʈ ��������
    }

    protected virtual void Update()
    {
        HandleAttackDelay();   // ���� ������ ó��
    }

    // ���� �����̸� ó���ϴ� �޼���
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
            CallAttackEvent(Stats.CurrentStats.attackSO);   // ���� �̺�Ʈ ȣ��
        }
    }

    // �̵� �̺�Ʈ ȣ�� �޼���
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    // �ٶ󺸴� ���� ���� �̺�Ʈ ȣ�� �޼���
    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    // ���� �̺�Ʈ ȣ�� �޼���
    public void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }
}