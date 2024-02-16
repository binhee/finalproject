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
        // �÷��̾� �̵�
        Vector2 movement = moveInput * speed * Time.deltaTime;
        rb.position = rb.position + movement;
        //rb.MovePosition(rb.position + movement);

        // ����
        if (isGround && jump)
        {
            jump = false;
            //rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            //rb.velocity = jumpInput + jumpPower * Time.deltaTime;

            Debug.Log("����");
            Debug.Log(rb.velocity);
        }
    }

    //�̵� �Է� ó��
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        jump = value.isPressed;
    }

    // �浹 ó��
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            Debug.Log("��");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
            Debug.Log("����");
        }
    }
}