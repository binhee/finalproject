using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class PlayerInputController : PlayerController
{
    private Camera _camera;          // 주 플레이어 카메라
    private Rigidbody2D _rigidbody;   // 주 플레이어 Rigidbody2D 컴포넌트

    private bool isJumping = false;   // 점프 중인지 여부
    private bool jumpCooldown = false; // 점프 쿨다운 상태
    public bool itemDoubleJumping = false; // 더블 점프 가능한 아이템 장착 여부

    [SerializeField] public float jumpForce = 20f;   // 점프 힘
    [SerializeField] private float jumpCooldownTime = 0.65f; // 점프 쿨다운 시간

    protected bool IsGrounded { get; set; } = true;   // 땅에 닿아 있는지 여부

    protected override void Awake()
    {
        base.Awake();
        _camera = Camera.main;   // 메인 카메라 가져오기
        _rigidbody = GetComponent<Rigidbody2D>();   // Rigidbody2D 컴포넌트 가져오기
    }

    // 이동 입력 처리
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;   // 정규화된 이동 입력 값
        CallMoveEvent(moveInput);   // 이동 이벤트 호출
    }

    // 바라보기 입력 처리
    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();   // 새로운 바라보는 방향 입력 값
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);   // 화면 좌표를 월드 좌표로 변환
        newAim = (worldPos - (Vector2)transform.position).normalized;   // 플레이어를 기준으로 바라보는 방향을 정규화

        if (newAim.magnitude >= 0.9f)
        {
            CallLookEvent(newAim);   // 바라보는 방향 이벤트 호출
        }
    }

    // 공격 입력 처리
    public void OnFire(InputValue value)
    {
        IsAttacking = value.isPressed;   // 공격 여부 갱신
    }

    // 점프 입력 처리
    public void OnJump(InputValue value)
    {
        if (IsGrounded && !isJumping && !jumpCooldown)   // 땅에 닿아 있고 점프 중이 아니며 점프 쿨다운 중이 아닌 경우
        {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);   // 점프 힘을 가해줌
            SoundManager.SoundInstance.PlaySFX(SoundManager.SoundInstance.JumpSound);   // 점프 사운드 재생.
            IsGrounded = false;   // 땅에 닿아 있지 않음으로 설정
            isJumping = true;   // 점프 중으로 설정
            StartCoroutine(JumpCooldown());   // 점프 쿨다운 코루틴 시작
        }
        else if(!IsGrounded && isJumping&& jumpCooldown&& itemDoubleJumping)
        {
            jumpCooldown = false;
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    // 땅에 닿았을 때 호출되는 이벤트
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;   // 땅에 닿아 있음으로 설정

            isJumping = false;   // 점프 중이 아님으로 설정
        }

        else if (collision.gameObject.CompareTag("wall"))
        {
            jumpCooldownTime = 0.15f;
            IsGrounded = true;   // 땅에 닿아 있음으로 설정
            isJumping = false;   // 점프 중이 아님으로 설정

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

    // 점프 쿨다운을 처리하는 코루틴
    IEnumerator JumpCooldown()
    {
        jumpCooldown = true; // 점프 쿨다운 활성화
        yield return new WaitForSeconds(jumpCooldownTime); // 일정 시간 동안 대기
        jumpCooldown = false; // 점프 쿨다운 비활성화
        IsGrounded = true;   // 다시 땅에 닿아 있음으로 설정
    }
}