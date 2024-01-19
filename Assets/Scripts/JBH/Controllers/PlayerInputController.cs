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

    private bool isJumping = false;

    [SerializeField] private float jumpForce ;

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
        if (IsGrounded && !isJumping)
        {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            IsGrounded = false;
            isJumping = true;
        }
        else if (!IsGrounded && isJumping)
        {
            
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
            isJumping = false;
        }
    }
}
