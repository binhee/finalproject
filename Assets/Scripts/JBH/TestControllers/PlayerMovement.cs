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
        // �÷��̾� �̵�
        Vector2 movement = moveInput * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        // ����
        if (isGrounded && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Debug.Log("����");
        }
    }

    //�̵� �Է� ó��
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    // �浹 ó��
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("��");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("����");
        }
    }
}