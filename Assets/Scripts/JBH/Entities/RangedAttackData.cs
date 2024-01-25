using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 원거리 공격 데이터를 정의하는 ScriptableObject 클래스
[CreateAssetMenu(fileName = "RangedAttackData", menuName = "Controller/Attacks/Ranged", order = 1)]
public class RangedAttackData : AttackSO
{
    [Header("Ranged Attack Data")]
    public string bulletNameTag;             // 발사체의 이름 태그
    public float duration;                   // 발사체 지속 시간
    public float spread;                     // 발사체의 퍼짐 정도
    public int numberofProjectilesPerShot;   // 한 번에 발사되는 발사체 수
    public float multipleProjectilesAngel;   // 다중 발사체의 각도 간격
    public Color projectileColor;            // 발사체 색상
}
