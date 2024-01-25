using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsChangeType
{
    Add,
    Multiple,
    Override,
}

// ĳ���� ���� ������ ���� Ŭ����
[Serializable]
public class CharacterStats
{
    public StatsChangeType statsChangeType;   // ���� ���� ����
    [Range(1, 100)] public int maxHealth;   // �ִ� ü��
    [Range(1, 20f)] public float speed;     // �̵� �ӵ�

    // ���� ������
    public AttackSO attackSO;   // ���� ������
}
