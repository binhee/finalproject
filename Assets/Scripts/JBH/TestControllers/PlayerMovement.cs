using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpPower;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    
    private bool isGround;
    bool jump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 플레이어 이동
        Vector2 movement = moveInput * speed * Time.deltaTime;
        rb.position = rb.position + movement;
        //rb.MovePosition(rb.position + movement);

        // 점프
        if (isGround && jump)
        {
            jump = false;
            //rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            //rb.velocity = jumpInput + jumpPower * Time.deltaTime;

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
        jump = value.isPressed;
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