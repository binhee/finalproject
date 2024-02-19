using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTile : MonoBehaviour
{
    public float rotationSpeed = 1.0f; // 로테이션 속도 조절을 위한 변수

    void Update()
    {
        // 타일의 현재 로테이션 값을 저장
        Vector3 currentRotation = transform.rotation.eulerAngles;

        // y 축을 기준으로 로테이션 값을 계속 더해줌
        currentRotation.z += rotationSpeed * Time.deltaTime;

        // 새로운 로테이션 값을 적용
        transform.rotation = Quaternion.Euler(currentRotation);
    }
}
