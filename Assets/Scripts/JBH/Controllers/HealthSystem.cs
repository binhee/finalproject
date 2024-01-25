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

    public event Action OnDamage;                 // �������� ���� �� ȣ��Ǵ� �̺�Ʈ
    public event Action OnHeal;                   // ġ���� �� ȣ��Ǵ� �̺�Ʈ
    public event Action OnDeath;                  // ����� �� ȣ��Ǵ� �̺�Ʈ
    public event Action OnInvincibilityEnd;       // ���� ���°� ���� �� ȣ��Ǵ� �̺�Ʈ

    public float CurrentHealth { get; private set; }   // ���� ü��

    public float MaxHealth => _statsHandler.CurrentStats.maxHealth;   // �ִ� ü��

    private void Awake()
    {
        _statsHandler = GetComponent<CharacterStatsHandler>();
    }

    private void Start()
    {
        CurrentHealth = _statsHandler.CurrentStats.maxHealth;   // ���� �� ���� ü���� �ִ� ü������ �ʱ�ȭ
    }

    private void Update()
    {
        if (_timeSinceLastChange < healthChangeDelay)
        {
            _timeSinceLastChange += Time.deltaTime;
            if (_timeSinceLastChange >= healthChangeDelay)
            {
                OnInvincibilityEnd?.Invoke();   // ���� ���°� ������ �� �̺�Ʈ ȣ��
            }
        }
    }

    public bool ChangeHealth(float change)
    {
        if (change == 0 || _timeSinceLastChange < healthChangeDelay)
        {
            return false;   // ���氪�� 0�̰ų�, ���� �ð� ���� �������� ���� �Ŀ��� ü���� �������� ����
        }

        _timeSinceLastChange = 0f;   // ü�� ���� �ð� �ʱ�ȭ
        CurrentHealth += change;    // ü�� ���� ����
        CurrentHealth = CurrentHealth > MaxHealth ? MaxHealth : CurrentHealth;   // �ִ� ü���� ���� �ʵ��� ����
        CurrentHealth = CurrentHealth < 0 ? 0 : CurrentHealth;   // ������ �������� �ʵ��� ����

        if (change > 0)
        {
            OnHeal?.Invoke();   // ġ�� �̺�Ʈ ȣ��
        }
        else
        {
            OnDamage?.Invoke();   // ������ �̺�Ʈ ȣ��
        }

        if (CurrentHealth <= 0f)
        {
            CallDeath();   // ü���� 0 ������ ��� ��� �̺�Ʈ ȣ��
        }

        return true;   // ü���� ����Ǿ����� ��ȯ
    }

    private void CallDeath()
    {
        OnDeath?.Invoke();   // ��� �̺�Ʈ ȣ��
    }
}
