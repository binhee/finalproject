using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCircle : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform delPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
            rb.isKinematic = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (transform.position == delPos.position)
        {
            Destroy(gameObject);
        }
    }
}
