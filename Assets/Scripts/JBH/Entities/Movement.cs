using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private PlayerController _controller;
    private CharacterStatsHandler _stats;

    private Vector2 _movementDirection = Vector2.zero;   // 이동 방향
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();   // PlayerController 컴포넌트 가져오기
        _stats = GetComponent<CharacterStatsHandler>();   // CharacterStatsHandler 컴포넌트 가져오기
        _rigidbody = GetComponent<Rigidbody2D>();   // Rigidbody2D 컴포넌트 가져오기
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;   // 이동 이벤트에 이동 함수 연결
    }

    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);   // 이동 방향 적용
    }

    // 이동 이벤트에서 호출되는 함수
    private void Move(Vector2 direction)
    {
        _movementDirection = direction;   // 이동 방향 갱신        
    }

    // Rigidbody2D에 이동 방향을 적용하는 함수
    private void ApplyMovement(Vector2 direction)
    {
        // 이동 방향에 플레이어 속도를 곱함
        direction = direction * _stats.CurrentStats.speed;

        // 수평 이동 속도 업데이트
        _rigidbody.velocity = new Vector2(direction.x, _rigidbody.velocity.y);
    }
}