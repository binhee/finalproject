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
    private Camera _camera;
    private Rigidbody2D _rigidbody;

    public float jumpForce = 10f;

    protected bool IsGrounded { get; set; } = true;

    protected override void Awake()
    {
        base.Awake();
        _camera = Camera.main;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputValue value)
    {
        //Debug.Log("OnMove" + value.ToString());
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        //Debug.Log("OnLook" + value.ToString());
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        if (newAim.magnitude >= .9f)
        {
            CallLookEvent(newAim);
        }
    }

    public void OnFire(InputValue value)
    {
        IsAttacking = value.isPressed;
    }
    public void OnJump(InputValue value)
    {
        if (value.isPressed && IsGrounded)
        {
            Jump(jumpForce);
        }
    }

    // 여기서부터 추가된 코드
    public void Jump(float jumpForce)
    {
        Debug.Log("점프!!");
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
        IsGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("점프 중~");
            IsGrounded = true;
        }
    }
}
