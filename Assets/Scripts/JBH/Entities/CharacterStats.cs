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

// 캐릭터 스탯 정보를 담은 클래스
[Serializable]
public class CharacterStats
{
    public StatsChangeType statsChangeType;   // 스탯 변경 유형
    [Range(1, 100)] public int maxHealth;   // 최대 체력
    [Range(1, 20f)] public float speed;     // 이동 속도

    // 공격 데이터
    public AttackSO attackSO;   // 공격 데이터
}
