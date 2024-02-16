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
        // �÷��̾� �̵�
        Vector2 movement = moveInput * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        // ����
        if (isGround && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);

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
        moveInput = value.Get<Vector2>();
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