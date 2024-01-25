using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���Ÿ� ���� �����͸� �����ϴ� ScriptableObject Ŭ����
[CreateAssetMenu(fileName = "RangedAttackData", menuName = "Controller/Attacks/Ranged", order = 1)]
public class RangedAttackData : AttackSO
{
    [Header("Ranged Attack Data")]
    public string bulletNameTag;             // �߻�ü�� �̸� �±�
    public float duration;                   // �߻�ü ���� �ð�
    public float spread;                     // �߻�ü�� ���� ����
    public int numberofProjectilesPerShot;   // �� ���� �߻�Ǵ� �߻�ü ��
    public float multipleProjectilesAngel;   // ���� �߻�ü�� ���� ����
    public Color projectileColor;            // �߻�ü ����
}
