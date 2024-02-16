using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpPower = 10f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 플레이어 이동
        Vector2 movement = moveInput * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        // 점프
        if (isGround && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);

            Debug.Log("점프");
            Debug.Log(rb.velocity);
        }
    }

    //이동 입력 처리
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    // 충돌 처리
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            Debug.Log("땅");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
            Debug.Log("공중");
        }
    }
}