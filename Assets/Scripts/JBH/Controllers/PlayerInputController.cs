using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerInputController : PlayerController
{
    private Camera _camera;          // �� �÷��̾� ī�޶�
    private Rigidbody2D _rigidbody;   // �� �÷��̾� Rigidbody2D ������Ʈ

    private bool isJumping = false;   // ���� ������ ����

    [SerializeField] private float jumpForce;   // ���� ��

    protected bool IsGrounded { get; set; } = true;   // ���� ��� �ִ��� ����

    protected override void Awake()
    {
        base.Awake();
        _camera = Camera.main;   // ���� ī�޶� ��������
        _rigidbody = GetComponent<Rigidbody2D>();   // Rigidbody2D ������Ʈ ��������
    }

    // �̵� �Է� ó��
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;   // ����ȭ�� �̵� �Է� ��
        CallMoveEvent(moveInput);   // �̵� �̺�Ʈ ȣ��
    }

    // �ٶ󺸱� �Է� ó��
    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();   // ���ο� �ٶ󺸴� ���� �Է� ��
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);   // ȭ�� ��ǥ�� ���� ��ǥ�� ��ȯ
        newAim = (worldPos - (Vector2)transform.position).normalized;   // �÷��̾ �������� �ٶ󺸴� ������ ����ȭ

        if (newAim.magnitude >= 0.9f)
        {
            CallLookEvent(newAim);   // �ٶ󺸴� ���� �̺�Ʈ ȣ��
        }
    }

    // ���� �Է� ó��
    public void OnFire(InputValue value)
    {
        IsAttacking = value.isPressed;   // ���� ���� ����
    }

    // ���� �Է� ó��
    public void OnJump(InputValue value)
    {
        if (IsGrounded && !isJumping)   // ���� ��� �ְ� ���� ���� �ƴ� ���
        {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);   // ���� ���� ������
            IsGrounded = false;   // ���� ��� ���� �������� ����
            isJumping = true;   // ���� ������ ����
        }
    }

    // ���� ����� �� ȣ��Ǵ� �̺�Ʈ
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;   // ���� ��� �������� ����
            isJumping = false;   // ���� ���� �ƴ����� ����
        }
    }
}