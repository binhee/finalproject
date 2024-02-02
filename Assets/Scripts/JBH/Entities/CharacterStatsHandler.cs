using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ĳ���� ������ �����ϴ� Ŭ����
public class CharacterStatsHandler : MonoBehaviour
{
    [SerializeField] public CharacterStats baseStats;   // �⺻ ���� ����
    public CharacterStats CurrentStats;   // ���� ���� ����
    public List<CharacterStats> statsModifiers = new List<CharacterStats>();   // ���� ������ ����Ʈ

    private void Awake()
    {
        UpdateCharacterStats();   // ĳ���� ���� ������Ʈ �޼��� ȣ��

    }
    // ĳ���� ���� ������Ʈ �޼���
    public void UpdateCharacterStats()
    {
        AttackSO attackSO = null;   // ���� ������ �ʱ�ȭ
        if (baseStats.attackSO != null)
        {
            attackSO = Instantiate(baseStats.attackSO);   // �⺻ ���� ������ ����
        }

        // ���� ���� ���� �ʱ�ȭ
        CurrentStats = new CharacterStats { attackSO = attackSO };
        CurrentStats.statsChangeType = baseStats.statsChangeType;
        CurrentStats.maxHealth = baseStats.maxHealth;
        CurrentStats.speed = baseStats.speed;
    }
}