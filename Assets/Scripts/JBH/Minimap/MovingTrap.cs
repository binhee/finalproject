using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTrap : MonoBehaviour
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
