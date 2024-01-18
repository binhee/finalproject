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
        // �ʱ�ȭ �� UI ������Ʈ
        foreach (var skill in skills)
        {
            // ��ų �̹��� �ʱ�ȭ
            skill.skillImage = skill.skillImage ?? GetComponent<Image>();

            // ��ų �� �ؽ�Ʈ �ʱ�ȭ
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
        // ��ų ������Ʈ
        foreach (var skill in skills)
        {
            if (skill.isOnCooldown)
            {
                UpdateCooldownUI(skill);
            }

            // Ű �Է� �� ��ų ���
            if (Input.GetKeyDown(skill.key))
            {
                UseSkill(skill);
            }
        }
    }

    // ��ų ��� �޼���
    void UseSkill(Skill skill)
    {
        if (!skill.isOnCooldown)
        {
            // ��ų ��� �� ��ų �� ���
            StartCoroutine(SkillCooldown(skill));
        }
        else
        {
            Debug.Log("��ų ���� ��� ��");
        }
    }

    // ��ų �� ��� �ð� ó��
    IEnumerator SkillCooldown(Skill skill)
    {
        skill.isOnCooldown = true;
        skill.skillImage.color = new Color(0.5f, 0.5f, 0.5f, 1f);  // ��ų �̹��� ��Ӱ� ����

        skill.cooldownTimer = skill.cooldownTime;  // ���� ���ð� �ʱ�ȭ

        while (skill.cooldownTimer > 0f)
        {
            skill.cooldownTimer -= Time.deltaTime;
            UpdateCooldownUI(skill);
            yield return null;
        }

        // ��ų ���� ������ �ʱ�ȭ
        skill.isOnCooldown = false;
        // ��ų �̹��� �������� ����
        skill.skillImage.color = Color.white;

        yield return null;
    }

    // ��ų �� �ߤ� UI ������Ʈ
    void UpdateCooldownUI(Skill skill)
    {
        if (skill.skillImage == null)
        {
            return;
        }

        float cooldownPercentage = Mathf.Clamp01(1 - (skill.cooldownTimer / Mathf.Max(skill.cooldownTime, 0.01f)));
        // ��ų �̹����� ���� ��� �ð� ǥ��
        skill.skillImage.fillAmount = cooldownPercentage;

        // ��ų�� ��Ÿ�� �� ���� �ؽ�Ʈ ǥ��
        if (skill.isOnCooldown)
        {
            if (skill.cooldownTimer > 0f)
            {
                // ���� ���� �ð��� �ؽ�Ʈ�� ǥ��
                skill.cooldownText.text = Mathf.CeilToInt(skill.cooldownTimer).ToString();
            }
            else
            {
                skill.cooldownText.text = null;  // �ؽ�Ʈ �����
                Debug.Log("���� ����");
            }
        }        
    }
}
