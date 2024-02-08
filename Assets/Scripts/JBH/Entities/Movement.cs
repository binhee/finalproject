using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private PlayerController _controller;
    private CharacterStatsHandler _stats;

    private Vector2 _movementDirection = Vector2.zero;   // �̵� ����
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();   // PlayerController ������Ʈ ��������
        _stats = GetComponent<CharacterStatsHandler>();   // CharacterStatsHandler ������Ʈ ��������
        _rigidbody = GetComponent<Rigidbody2D>();   // Rigidbody2D ������Ʈ ��������
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;   // �̵� �̺�Ʈ�� �̵� �Լ� ����
    }

    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);   // �̵� ���� ����
    }

    // �̵� �̺�Ʈ���� ȣ��Ǵ� �Լ�
    private void Move(Vector2 direction)
    {
        _movementDirection = direction;   // �̵� ���� ����        
    }

    // Rigidbody2D�� �̵� ������ �����ϴ� �Լ�
    private void ApplyMovement(Vector2 direction)
    {
        // �̵� ���⿡ �÷��̾� �ӵ��� ����
        direction = direction * _stats.CurrentStats.speed;

        // ���� �̵� �ӵ� ������Ʈ
        _rigidbody.velocity = new Vector2(direction.x, _rigidbody.velocity.y);
    }
}