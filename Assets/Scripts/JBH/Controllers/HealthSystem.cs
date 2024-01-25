using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float healthChangeDelay = .5f;

    private CharacterStatsHandler _statsHandler;
    private float _timeSinceLastChange = float.MaxValue;

    public event Action OnDamage;                 // 데미지를 입을 때 호출되는 이벤트
    public event Action OnHeal;                   // 치유될 때 호출되는 이벤트
    public event Action OnDeath;                  // 사망할 때 호출되는 이벤트
    public event Action OnInvincibilityEnd;       // 무적 상태가 끝날 때 호출되는 이벤트

    public float CurrentHealth { get; private set; }   // 현재 체력

    public float MaxHealth => _statsHandler.CurrentStats.maxHealth;   // 최대 체력

    private void Awake()
    {
        _statsHandler = GetComponent<CharacterStatsHandler>();
    }

    private void Start()
    {
        CurrentHealth = _statsHandler.CurrentStats.maxHealth;   // 시작 시 현재 체력을 최대 체력으로 초기화
    }

    private void Update()
    {
        if (_timeSinceLastChange < healthChangeDelay)
        {
            _timeSinceLastChange += Time.deltaTime;
            if (_timeSinceLastChange >= healthChangeDelay)
            {
                OnInvincibilityEnd?.Invoke();   // 무적 상태가 끝났을 때 이벤트 호출
            }
        }
    }

    public bool ChangeHealth(float change)
    {
        if (change == 0 || _timeSinceLastChange < healthChangeDelay)
        {
            return false;   // 변경값이 0이거나, 일정 시간 동안 데미지를 받은 후에는 체력을 변경하지 않음
        }

        _timeSinceLastChange = 0f;   // 체력 변경 시간 초기화
        CurrentHealth += change;    // 체력 변경 적용
        CurrentHealth = CurrentHealth > MaxHealth ? MaxHealth : CurrentHealth;   // 최대 체력을 넘지 않도록 조정
        CurrentHealth = CurrentHealth < 0 ? 0 : CurrentHealth;   // 음수로 떨어지지 않도록 조정

        if (change > 0)
        {
            OnHeal?.Invoke();   // 치유 이벤트 호출
        }
        else
        {
            OnDamage?.Invoke();   // 데미지 이벤트 호출
        }

        if (CurrentHealth <= 0f)
        {
            CallDeath();   // 체력이 0 이하일 경우 사망 이벤트 호출
        }

        return true;   // 체력이 변경되었음을 반환
    }

    private void CallDeath()
    {
        OnDeath?.Invoke();   // 사망 이벤트 호출
    }
}
