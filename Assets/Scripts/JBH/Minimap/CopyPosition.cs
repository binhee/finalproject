using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPosition : MonoBehaviour
{
    [SerializeField] private bool x, y, z;   // 복사할 좌표 축 설정
    [SerializeField] private Transform target;   // 대상(Transform) 설정

    private void Update()
    {
        if (!target) return;   // 대상이 null이면 함수 종료

        // 선택한 좌표 축에 대한 값을 대상의 좌표로 복사
        transform.position = new Vector3(
            (x ? target.position.x : transform.position.x),
            (y ? target.position.y : transform.position.y),
            (z ? target.position.z : transform.position.z)
        );
    }
}
