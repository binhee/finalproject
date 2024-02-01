using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;

public class PlayerInputController : PlayerController
{
    private Camera _camera;          // �� �÷��̾� ī�޶�
    private Rigidbody2D _rigidbody;   // �� �÷��̾� Rigidbody2D ������Ʈ

    private bool isJumping = false;   // ���� ������ ����
    private bool jumpCooldown = false; // ���� ��ٿ� ����
    public bool itemDoubleJumping = false; // ���� ���� ������ ������ ���� ����

    [SerializeField] public float jumpForce;   // ���� ��
    [SerializeField] private float jumpCooldownTime = 0.7f; // ���� ��ٿ� �ð�

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
        if (IsGrounded && !isJumping && !jumpCooldown)   // ���� ��� �ְ� ���� ���� �ƴϸ� ���� ��ٿ� ���� �ƴ� ���
        {
            Debug.Log("a");
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);   // ���� ���� ������
            IsGrounded = false;   // ���� ��� ���� �������� ����
            isJumping = true;   // ���� ������ ����
            StartCoroutine(JumpCooldown());   // ���� ��ٿ� �ڷ�ƾ ����
        }
        if(!IsGrounded && isJumping&& jumpCooldown&& itemDoubleJumping)
        {
            Debug.Log("b");
            jumpCooldown = false;
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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

    // ���� ��ٿ��� ó���ϴ� �ڷ�ƾ
    IEnumerator JumpCooldown()
    {
        jumpCooldown = true; // ���� ��ٿ� Ȱ��ȭ
        yield return new WaitForSeconds(jumpCooldownTime); // ���� �ð� ���� ���
        jumpCooldown = false; // ���� ��ٿ� ��Ȱ��ȭ
        IsGrounded = true;   // �ٽ� ���� ��� �������� ����
    }
}