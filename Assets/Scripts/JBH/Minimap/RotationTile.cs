using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTile : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;
    public Transform desPos;
    public float speed;

    void Start()
    {
        transform.position = startPos.position;
        desPos = endPos;
    }

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

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, desPos.position, Time.deltaTime * speed);

        if (Vector2.Distance(transform.position, desPos.position) <= 0.05f)
        {
            // 목적 위치 도달 시 다음 이동 방향을 설정
            if (desPos == endPos) desPos = startPos;
            else desPos = endPos;
        }
    }
}
