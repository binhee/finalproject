using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultAttackData", menuName = "Controller/Attacks/Default", order = 0)]
// ScriptableObject를 사용하여 공격 데이터를 생성하는 클래스
public class AttackSO : ScriptableObject
{
    [Header("Attack Info")]
    public float size;   // 공격의 크기
    public float delay;   // 공격 딜레이
    public float power;   // 공격의 힘
    public float speed;   // 공격 속도
    public LayerMask target;   // 타겟 레이어 마스크
}
