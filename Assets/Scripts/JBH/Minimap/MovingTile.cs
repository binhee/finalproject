using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTile : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;
    public Transform desPos;
    //public Transform telPos;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos.position;
        desPos = endPos;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }

       
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, desPos.position, Time.deltaTime * speed);

        //if (transform.position == telPos.position)
        //{
        //    // ���� �̵�
        //    transform.position = startPos.position;
        //}

        if (Vector2.Distance(transform.position, desPos.position) <= 0.05f)
        {
            // ���� ��ġ ���� �� ���� �̵� ������ ����
            if (desPos == endPos) desPos = startPos;
            else desPos = endPos;
        }
    }
}
