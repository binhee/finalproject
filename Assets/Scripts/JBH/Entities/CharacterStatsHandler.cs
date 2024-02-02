using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 캐릭터 스탯을 관리하는 클래스
public class CharacterStatsHandler : MonoBehaviour
{
    [SerializeField] public CharacterStats baseStats;   // 기본 스탯 정보
    public CharacterStats CurrentStats;   // 현재 스탯 정보
    public List<CharacterStats> statsModifiers = new List<CharacterStats>();   // 스탯 수정자 리스트

    private void Awake()
    {
        UpdateCharacterStats();   // 캐릭터 스탯 업데이트 메서드 호출

    }
    // 캐릭터 스탯 업데이트 메서드
    public void UpdateCharacterStats()
    {
        AttackSO attackSO = null;   // 공격 데이터 초기화
        if (baseStats.attackSO != null)
        {
            attackSO = Instantiate(baseStats.attackSO);   // 기본 공격 데이터 복제
        }

        // 현재 스탯 정보 초기화
        CurrentStats = new CharacterStats { attackSO = attackSO };
        CurrentStats.statsChangeType = baseStats.statsChangeType;
        CurrentStats.maxHealth = baseStats.maxHealth;
        CurrentStats.speed = baseStats.speed;
    }
}