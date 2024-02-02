using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TitleBakcPlayerMove : MonoBehaviour
{
    public float limitPosX;
    public float limitPosY;
    public bool moveDirection;
    public float speed;
    public float speedChangeTime;

    float time;
    void Update()
    {
       // LimitY(limitPosY);
        Speed();
        Direction();
        Move(moveDirection);
    }
    void Move(bool side)
    {
        if (side)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
    void Direction()
    {
        if (limitPosX < transform.position.x)
        {
            moveDirection = true;
            transform.localScale = new Vector3(-1, 1, 0);
        }
        else if(-limitPosX> transform.position.x)
        {
            moveDirection = false;
            transform.localScale = new Vector3(1, 1, 0);
        }
    }
    void Speed()
    {
        time += Time.deltaTime;
        if(time> speedChangeTime)
        {
            time = 0;
            speed = Random.RandomRange(2, 9);
        }
    }
    void LimitY(float limit)
    {
        if(transform.position.y <= limit)
        {
            Vector3 pos = transform.position;
            pos.y = limit;
            transform.position = pos;
        }
    }
}
