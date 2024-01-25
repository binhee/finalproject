using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer CharacterRenderer;   // 캐릭터 SpriteRenderer 컴포넌트
    [SerializeField] private SpriteRenderer armRenderer;         // 팔 SpriteRenderer 컴포넌트
    [SerializeField] private Transform armPivot;                 // 팔의 회전 중심 축

    private PlayerController _controller;   // PlayerController 스크립트

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();   // PlayerController 스크립트 가져오기
    }

    void Start()
    {
        _controller.OnLookEvent += OnAim;   // 바라보기 이벤트에 바라보기 함수 연결
    }

    // 바라보기 함수
    public void OnAim(Vector2 newAimDirection)
    {
        RotateArm(newAimDirection);   // 팔을 회전시키는 함수 호출
    }

    // 팔을 주어진 방향으로 회전시키는 함수
    private void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;   // 주어진 방향으로 각도 계산

        armRenderer.flipY = Mathf.Abs(rotZ) > 90f;   // 팔의 각도에 따라 Sprite 뒤집기
        CharacterRenderer.flipX = armRenderer.flipY;   // 팔이 뒤집힐 때 캐릭터도 뒤집기
        armPivot.rotation = Quaternion.Euler(0, 0, rotZ);   // 팔 중심 축을 기준으로 회전
    }
}