using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SkillController : MonoBehaviour
{
    [System.Serializable]
    public class Skill
    {
        public KeyCode key;
        public Image skillImage;
        public Text cooldownText;
        public float cooldownTime = 5f;
        public bool isOnCooldown = false;
        public float cooldownTimer;
    }

    public List<Skill> skills;

    void Start()
    {
        // 초기화 시 UI 업데이트
        foreach (var skill in skills)
        {
            // 스킬 이미지 초기화
            skill.skillImage = skill.skillImage ?? GetComponent<Image>();

            // 스킬 쿨 텍스트 초기화
            skill.cooldownText = skill.cooldownText ?? GetComponentInChildren<Text>();

            if (skill.cooldownText == null)
            {
                Debug.LogError("CooldownText not found for skill: " + skill.key);
            }

            UpdateCooldownUI(skill);
        }
    }

    void Update()
    {
        // 스킬 업데이트
        foreach (var skill in skills)
        {
            if (skill.isOnCooldown)
            {
                UpdateCooldownUI(skill);
            }

            // 키 입력 시 스킬 사용
            if (Input.GetKeyDown(skill.key))
            {
                UseSkill(skill);
            }
        }
    }

    // 스킬 사용 메서드
    void UseSkill(Skill skill)
    {
        if (!skill.isOnCooldown)
        {
            // 스킬 사용 후 스킬 쿨 대기
            StartCoroutine(SkillCooldown(skill));
        }
        else
        {
            Debug.Log("스킬 재사용 대기 중");
        }
    }

    // 스킬 쿨 대기 시간 처리
    IEnumerator SkillCooldown(Skill skill)
    {
        skill.isOnCooldown = true;
        skill.skillImage.color = new Color(0.5f, 0.5f, 0.5f, 1f);  // 스킬 이미지 어둡게 변경

        skill.cooldownTimer = skill.cooldownTime;  // 재사용 대기시간 초기화

        while (skill.cooldownTimer > 0f)
        {
            skill.cooldownTimer -= Time.deltaTime;
            UpdateCooldownUI(skill);
            yield return null;
        }

        // 스킬 쿨이 끝나면 초기화
        skill.isOnCooldown = false;
        // 스킬 이미지 기존으로 변경
        skill.skillImage.color = Color.white;

        yield return null;
    }

    // 스킬 쿨 중ㅇ UI 업데이트
    void UpdateCooldownUI(Skill skill)
    {
        if (skill.skillImage == null)
        {
            return;
        }

        float cooldownPercentage = Mathf.Clamp01(1 - (skill.cooldownTimer / Mathf.Max(skill.cooldownTime, 0.01f)));
        // 스킬 이미지에 재사용 대기 시간 표시
        skill.skillImage.fillAmount = cooldownPercentage;

        // 스킬이 쿨타임 일 때만 텍스트 표시
        if (skill.isOnCooldown)
        {
            if (skill.cooldownTimer > 0f)
            {
                // 남은 재사용 시간을 텍스트로 표시
                skill.cooldownText.text = Mathf.CeilToInt(skill.cooldownTimer).ToString();
            }
            else
            {
                skill.cooldownText.text = null;  // 텍스트 숨기기
                Debug.Log("재사용 가능");
            }
        }        
    }
}
