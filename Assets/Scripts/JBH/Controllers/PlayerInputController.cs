using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class PlayerInputController : PlayerController
{
    private Camera _camera;          // �� �÷��̾� ī�޶�
    private Rigidbody2D _rigidbody;   // �� �÷��̾� Rigidbody2D ������Ʈ

    private bool isJumping = false;   // ���� ������ ����
    private bool jumpCooldown = false; // ���� ��ٿ� ����
    public bool itemDoubleJumping = false; // ���� ���� ������ ������ ���� ����

    [SerializeField] public float jumpForce = 20f;   // ���� ��
    [SerializeField] private float jumpCooldownTime = 0.65f; // ���� ��ٿ� �ð�

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
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);   // ���� ���� ������
            SoundManager.SoundInstance.PlaySFX(SoundManager.SoundInstance.JumpSound);   // ���� ���� ���.
            IsGrounded = false;   // ���� ��� ���� �������� ����
            isJumping = true;   // ���� ������ ����
            StartCoroutine(JumpCooldown());   // ���� ��ٿ� �ڷ�ƾ ����
        }
        else if(!IsGrounded && isJumping&& jumpCooldown&& itemDoubleJumping)
        {
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

        else if (collision.gameObject.CompareTag("wall"))
        {
            jumpCooldownTime = 0.15f;
            IsGrounded = true;   // ���� ��� �������� ����
            isJumping = false;   // ���� ���� �ƴ����� ����

            jumpForce = 17f;
            _rigidbody.gravityScale = 1.5f;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            jumpForce = 20f;
            _rigidbody.gravityScale = 3.5f;
            jumpCooldownTime = 0.65f;
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