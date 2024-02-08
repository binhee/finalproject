using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isGrounded;

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
        if (isGrounded && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Debug.Log("점프");
        }
    }

    //이동 입력 처리
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    // 충돌 처리
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("땅");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("공중");
        }
    }
}