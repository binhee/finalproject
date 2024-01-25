using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultAttackData", menuName = "Controller/Attacks/Default", order = 0)]
// ScriptableObject�� ����Ͽ� ���� �����͸� �����ϴ� Ŭ����
public class AttackSO : ScriptableObject
{
    [Header("Attack Info")]
    public float size;   // ������ ũ��
    public float delay;   // ���� ������
    public float power;   // ������ ��
    public float speed;   // ���� �ӵ�
    public LayerMask target;   // Ÿ�� ���̾� ����ũ
}
